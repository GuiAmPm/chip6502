using Chip6502.Decoder;
using Chip6502.Emulator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Chip6502.Visualizer
{
    public partial class ChipVisualizerMainForm : Form
    {
        private const int PC_MEMORY_ROWS = 3,
                          STACK_MEMORY_ROWS = 3,
                          MEM_READ_ROWS = 5,
                          MEM_WRITE_ROWS = 5,
                          DECODE_PC_NEGATIVE_ROWS = 0xB,
                          DECODE_PC_POSITIVE_ROWS = 0xB;

        private static readonly Color HIGHLIGHT_COLOR = Color.Red;

        private Chip CPU;
        private Queue<string> prevOperations;
        private List<string> nextOperations;

        private volatile bool running = false;
        private volatile bool breakOnPC = false;
        private volatile bool breakOnReadMem = false;
        private volatile bool breakOnWriteMem = false;

        private volatile int breakOnPCValue = 0;
        private volatile int breakOnReadMemValue = 0;
        private volatile int breakOnWriteMemValue = 0;

        public ChipVisualizerMainForm()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            CPU = new Chip(0);
            prevOperations = new Queue<string>();

            UpdateOperationData(false);
            UpdateVisualization();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reset();
            ResetHighlight();
        }

        private void UpdateVisualization()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateVisualization()));
                return;
            }

            ResetHighlight();
            HighlightChanges();

            PCNumInput.Value = CPU.State.PC;
            SPNumInput.Value = CPU.State.SP;

            AccNumInput.Value = CPU.State.A;
            XRegNumInput.Value = CPU.State.X;
            YRegNumInput.Value = CPU.State.Y;

            NegativeFlagCheck.Checked = CPU.State.NFlag;
            OverflowFlagCheck.Checked = CPU.State.VFlag;
            BreakFlagCheck.Checked = CPU.State.BFlag;
            DecimalFlagCheck.Checked = CPU.State.DFlag;
            InterruptFlagCheck.Checked = CPU.State.IFlag;
            ZeroFlagCheck.Checked = CPU.State.ZFlag;
            CarryFlagCheck.Checked = CPU.State.CFlag;

            DisplayMemory(PCMemoryText,
                          CPU.State.PC,
                          PC_MEMORY_ROWS,
                          0x0000,
                          0xFFFF);

            DisplayMemory(StackMemoryText,
                          ChipState.STACK_ADDR_START + CPU.State.SP,
                          STACK_MEMORY_ROWS,
                          ChipState.STACK_ADDR_START,
                          ChipState.STACK_ADDR_END);

            DisplayMemory(LastMemoryReadText,
                          CPU.Memory.LastReadDirectAddress,
                          MEM_WRITE_ROWS,
                          0x0000,
                          0xFFFF);

            DisplayMemory(LastMemoryWrittenText,
                          CPU.Memory.LastWriteDirectAddress,
                          MEM_WRITE_ROWS,
                          0x0000, 0xFFFF);

            UpdateOperationHistory();
            UpdateNextLine();
            UpdateLinesAfterPC();
        }

        private void HighlightChanges()
        {
            if (AccNumInput.Value != CPU.State.A) { AccNumInput.ForeColor = HIGHLIGHT_COLOR; }
            if (XRegNumInput.Value != CPU.State.X) { XRegNumInput.ForeColor = HIGHLIGHT_COLOR; }
            if (YRegNumInput.Value != CPU.State.Y) { YRegNumInput.ForeColor = HIGHLIGHT_COLOR; }

            if (NegativeFlagCheck.Checked != CPU.State.NFlag) { NegativeFlagCheck.ForeColor = HIGHLIGHT_COLOR; }
            if (OverflowFlagCheck.Checked != CPU.State.VFlag) { OverflowFlagCheck.ForeColor = HIGHLIGHT_COLOR; }
            if (BreakFlagCheck.Checked != CPU.State.BFlag) { BreakFlagCheck.ForeColor = HIGHLIGHT_COLOR; }
            if (DecimalFlagCheck.Checked != CPU.State.DFlag) { DecimalFlagCheck.ForeColor = HIGHLIGHT_COLOR; }
            if (InterruptFlagCheck.Checked != CPU.State.IFlag) { InterruptFlagCheck.ForeColor = HIGHLIGHT_COLOR; }
            if (ZeroFlagCheck.Checked != CPU.State.ZFlag) { ZeroFlagCheck.ForeColor = HIGHLIGHT_COLOR; }
            if (CarryFlagCheck.Checked != CPU.State.CFlag) { CarryFlagCheck.ForeColor = HIGHLIGHT_COLOR; }
        }

        private void ResetHighlight()
        {
            AccNumInput.ForeColor = Color.Black;
            XRegNumInput.ForeColor = Color.Black;
            YRegNumInput.ForeColor = Color.Black;

            NegativeFlagCheck.ForeColor = Color.Black;
            OverflowFlagCheck.ForeColor = Color.Black;
            BreakFlagCheck.ForeColor = Color.Black;
            DecimalFlagCheck.ForeColor = Color.Black;
            InterruptFlagCheck.ForeColor = Color.Black;
            ZeroFlagCheck.ForeColor = Color.Black;
            CarryFlagCheck.ForeColor = Color.Black;
        }

        private void DisplayMemory(RichTextBox richTextBox,
                                   int address,
                                   int rows,
                                   int minAddress,
                                   int maxAddress)
        {
            richTextBox.Text = string.Empty;

            if (address < minAddress
               || address > maxAddress)
            {
                throw new ArgumentOutOfRangeException(nameof(address), "Trying to access an invalid memory space.");
            }

            DisplayMemoryHeader(richTextBox);

            var addressStart = Math.Max(((address) & (~0xF)) - (rows / 2 * 0x10), minAddress);

            for (int row = 0; row < rows; row++)
            {
                var hasMore = DisplayMemRow(richTextBox,
                                            address,
                                            maxAddress,
                                            addressStart,
                                            row);

                if (!hasMore) break;
            }

        }

        private bool DisplayMemRow(RichTextBox richTextBox,
                                   int address,
                                   int maxAddress,
                                   int addressStart,
                                   int row)
        {
            richTextBox.AppendText(Environment.NewLine);
            var currentRow = addressStart + row * 0x10;

            if (currentRow > maxAddress) { return false; }

            richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
            richTextBox.AppendText($"{currentRow:X4}");

            richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);
            for (int i = 0; i <= 0x0F; i++)
            {
                var currAddress = currentRow + i;

                if (currAddress > maxAddress) { return false; }

                if (currAddress == address) { richTextBox.SelectionColor = HIGHLIGHT_COLOR; }
                else { richTextBox.SelectionColor = Color.Black; }

                richTextBox.AppendText($" {CPU.Memory.ReadByte(currAddress, ChipMemory.Operation.None):X2}");
            }

            return true;
        }

        private static void DisplayMemoryHeader(RichTextBox richTextBox)
        {
            richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
            richTextBox.AppendText("---- ");

            for (int i = 0; i <= 0x0F; i++)
            {
                richTextBox.AppendText($"{i:X2} ");
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void AccNumInput_ValueChanged(object sender, EventArgs e)
        {
            if (running) return;

            CPU.State.A = (int)AccNumInput.Value;
            UpdateVisualization();
        }

        private void XRegNumInput_ValueChanged(object sender, EventArgs e)
        {
            if (running) return;

            CPU.State.X = (int)XRegNumInput.Value;
            UpdateVisualization();
        }

        private void YRegNumInput_ValueChanged(object sender, EventArgs e)
        {
            if (running) return;

            CPU.State.Y = (int)YRegNumInput.Value;
            UpdateVisualization();
        }

        private void NegativeFlagCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (running) return;

            CPU.State.NFlag = NegativeFlagCheck.Checked;
            UpdateVisualization();
        }

        private void OverflowFlagCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (running) return;

            CPU.State.VFlag = OverflowFlagCheck.Checked;
            UpdateVisualization();
        }

        private void BreakFlagCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (running) return;

            CPU.State.BFlag = BreakFlagCheck.Checked;
            UpdateVisualization();
        }

        private void DecimalFlagCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (running) return;

            CPU.State.DFlag = DecimalFlagCheck.Checked;
            UpdateVisualization();
        }

        private void InterruptFlagCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (running) return;

            CPU.State.IFlag = InterruptFlagCheck.Checked;
            UpdateVisualization();
        }

        private void ZeroFlagCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (running) return;

            CPU.State.ZFlag = ZeroFlagCheck.Checked;
            UpdateVisualization();
        }

        private void CarryFlagCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (running) return;

            CPU.State.CFlag = CarryFlagCheck.Checked;
            UpdateVisualization();
        }

        private void SPNumInput_ValueChanged(object sender, EventArgs e)
        {
            if (running) return;

            CPU.State.SP = (int)SPNumInput.Value;
            UpdateVisualization();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Bin files|*.bin"
            };


            using (ofd)
            {
                var r = ofd.ShowDialog();


                if (r != DialogResult.Cancel && ofd.CheckFileExists)
                {
                    using (var stream = ofd.OpenFile())
                    {
                        CPU.Memory.Load(stream, CPU.State.PC);
                    }
                }
            }

            UpdateOperationData(false);
            UpdateVisualization();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            running = true;

            var speed = (int)SpeedNumInput.Value;
            var delay = speed / 1000f;
            bool limit = LimitCheck.Checked;


            Thread updateThread = null;

            Thread t = new Thread(() =>
            {
                LockButtons();

                while (running)
                {
                    lock (CPU)
                    {

                        CPU.Step();

                        UpdateOperationData(true);

                        if (breakOnPC && breakOnPCValue == CPU.State.PC) running = false;
                        if (breakOnReadMem && breakOnReadMemValue == CPU.Memory.LastReadDirectAddress) running = false;
                        if (breakOnWriteMem && breakOnWriteMemValue == CPU.Memory.LastWriteDirectAddress) running = false;
                    }

                    if (updateThread == null || !updateThread.IsAlive)
                    {
                        updateThread = new Thread(() =>
                        {
                            lock (CPU)
                            {
                                UpdateVisualization();
                            }

                            Application.DoEvents();
                        });

                        updateThread.Start();
                    }

                    if (limit)
                    {
                        var sleepTime = CPU.State.CycleBuffer / delay;

                        if (sleepTime > 0)
                        {
                            Thread.Sleep((int)sleepTime);
                            CPU.State.CycleBuffer = 0;
                        }
                    }
                    else
                    {

                    }
                }

                UnlockButtons();
                UpdateVisualization();
            });

            t.Start();
        }

        private void UnlockButtons()
        {
            LockButtons(false);
        }

        private void LockButtons(bool @lock = true)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => LockButtons(@lock)));
                return;
            }

            RunButton.Enabled = !@lock;
            StepButton.Enabled = !@lock;

            StopButton.Enabled = @lock;

            PCNumInput.ReadOnly = @lock;
            SPNumInput.ReadOnly = @lock;
            SpeedNumInput.ReadOnly = @lock;
            AccNumInput.ReadOnly = @lock;
            XRegNumInput.ReadOnly = @lock;
            YRegNumInput.ReadOnly = @lock;

            NegativeFlagCheck.Enabled = !@lock;
            OverflowFlagCheck.Enabled = !@lock;
            BreakFlagCheck.Enabled = !@lock;
            DecimalFlagCheck.Enabled = !@lock;
            InterruptFlagCheck.Enabled = !@lock;
            ZeroFlagCheck.Enabled = !@lock;
            CarryFlagCheck.Enabled = !@lock;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            running = false;
        }

        private void BreakMemReadCheck_CheckedChanged(object sender, EventArgs e)
        {
            breakOnReadMem = BreakMemReadCheck.Checked;
        }

        private void BreakMemSetCheck_CheckedChanged(object sender, EventArgs e)
        {
            breakOnWriteMem = BreakMemSetCheck.Checked;
        }

        private void BreakPCCheck_CheckedChanged(object sender, EventArgs e)
        {
            breakOnPC = BreakPCCheck.Checked;
        }

        private void BreakMemReadNumInput_ValueChanged(object sender, EventArgs e)
        {
            breakOnReadMemValue = (int)BreakMemReadNumInput.Value;
        }

        private void BreakMemSetNumInput_ValueChanged(object sender, EventArgs e)
        {
            breakOnWriteMemValue = (int)BreakMemSetNumInput.Value;
        }

        private void BreakPCNumInput_ValueChanged(object sender, EventArgs e)
        {
            breakOnPCValue = (int)BreakPCNumInput.Value;
        }

        private void StepButton_Click(object sender, EventArgs e)
        {
            running = true;

            CPU.Step();
            UpdateOperationData(true);
            UpdateVisualization();

            running = false;
        }

        private void UpdateOperationData(bool executed)
        {
            lock (prevOperations)
            {
                if (nextOperations != null && executed)
                {
                    prevOperations.Enqueue(nextOperations[0]);
                }

                if (prevOperations.Count > DECODE_PC_NEGATIVE_ROWS)
                {
                    prevOperations.Dequeue();
                }
            }

            nextOperations = InstructionDecoding.DecodeNextOperations(CPU, DECODE_PC_POSITIVE_ROWS + 1);
        }

        private void UpdateOperationHistory()
        {
            StringBuilder decodedProgram = new StringBuilder();

            int index = (prevOperations.Count);

            lock (prevOperations)
            {
                foreach (var prevOp in prevOperations)
                {
                    var curIndex = index--;

                    decodedProgram.AppendFormat(" -{0:X2} {1}{2}", curIndex, prevOp, Environment.NewLine);
                }
            }

            HistoryText.Text = decodedProgram.ToString();
        }

        private void UpdateNextLine()
        {
            NextLineText.Text = string.Format("     {0}{1}", nextOperations.First(), Environment.NewLine);
        }

        private void UpdateLinesAfterPC()
        {
            var index = 0;

            StringBuilder decodedResult = new StringBuilder();

            foreach (var nextOp in nextOperations.Skip(1))
            {
                var curIndex = index++;
                decodedResult.AppendFormat(" +{0:X2} {1}{2}", curIndex, nextOp, Environment.NewLine);
            }

            DecodedText.Text = decodedResult.ToString();
        }

        private void PCNumInput_ValueChanged(object sender, EventArgs e)
        {
            CPU.State.PC = (int)PCNumInput.Value;

            UpdateOperationData(false);

            UpdateNextLine();
            UpdateLinesAfterPC();

            UpdateVisualization();
        }
    }
}
