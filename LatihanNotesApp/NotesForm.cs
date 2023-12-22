using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LatihanNotesApp
{
    public partial class NotesForm : Form
    {
        NotesAppEntities entities = new NotesAppEntities();

        public NotesForm()
        {
            InitializeComponent();
        }

        private void NotesForm_Load(object sender, EventArgs e)
        {
            bindingSource1.AddNew();
            getNotes();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                Alerts.Error("Semua input wajib di isi !");
                return;
            }

            if (bindingSource1.Current is Note note)
            {
                entities.Notes.Add(note);
                int row = entities.SaveChanges();
                if (row > 0)
                {
                    Alerts.Success("Note berhasil di tambahkan !");
                    getNotes();
                    clearInput();
                    return;
                }
                Alerts.Error("Note gagal di tambahkan !");
            }
        }

        public void getNotes()
        {
            panel1.Controls.Clear();

            var notes = entities.Notes.ToList();
            bindingSource2.DataSource = notes;

            foreach (var note in bindingSource2.DataSource as List<Note>)
            {
                addControl(new NotesUserControl(this, note));
            }
        }

        public void addControl(UserControl control)
        {
            control.Dock = DockStyle.Top;
            panel1.Controls.Add(control);
        }

        public void clearInput()
        {
            bindingSource1.Clear();
        }
    }
}
