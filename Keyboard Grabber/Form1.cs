using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Keyboard_Grabber
{
    public partial class s : Form
    {
        public s()
        {
            InitializeComponent();
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {

            try
            {
                // Check if there is text in the clipboard
                if (Clipboard.ContainsText())
                {
                    // Get the clipboard text
                    string clipboardText = Clipboard.GetText();

                    // Get the current time
                    string timestamp = DateTime.Now.ToString("hh:mm:ss tt");

                    // Append the clipboard text with timestamp to the text box
                    textBoxMain.AppendText($"[{timestamp}] {clipboardText}{Environment.NewLine}");
                }
                else
                {
                    MessageBox.Show("Clipboard does not contain text.", "No Text Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {

            try
            {
                // Check if the textbox has any text
                if (!string.IsNullOrWhiteSpace(textBoxMain.Text))
                {
                    // Copy the content of the textbox to the clipboard
                    Clipboard.SetText(textBoxMain.Text);
                    MessageBox.Show("Text copied to clipboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Text box is empty. Nothing to copy.", "No Text Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            try
            {
                // Check if the textbox has any text
                if (!string.IsNullOrWhiteSpace(textBoxMain.Text))
                {
                    // Open a SaveFileDialog to allow the user to save the content
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                        saveFileDialog.Title = "Save Clipboard Text";
                        saveFileDialog.FileName = "ClipboardText.txt";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Write the content of the text box to the selected file
                            File.WriteAllText(saveFileDialog.FileName, textBoxMain.Text);
                            MessageBox.Show("File saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Text box is empty. Nothing to save.", "No Text Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void clipboardTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}