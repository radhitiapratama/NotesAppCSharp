using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace LatihanNotesApp
{
    public partial class NotesUserControl : UserControl
    {
        Note note;
        NotesForm form;
        NotesAppEntities entities = new NotesAppEntities();

        public NotesUserControl(NotesForm form, Note note)
        {
            InitializeComponent();
            this.form = form;
            this.note = note;
        }

        private void NotesUserControl_Load(object sender, EventArgs e)
        {
            string date = Convert.ToString(this.note.Date);
            label1.Text = Format.FormatDate(date, "dd/MM/yyyy HH:mm:ss", "dd MMMM yyyy HH:mm:ss");
            textBox1.Text = this.note.Description;
            bindingSource1.DataSource = this.note;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = Alerts.Confirm("Apakah anda yakin ingin menhapus note ?");
            if (dr == DialogResult.Yes)
            {
                var note = entities.Notes.First(f => f.ID == this.note.ID);
                entities.Notes.Remove(note);
                entities.SaveChanges();
                this.form.getNotes();
                Alerts.Success("Note berhasil di hapus !");
                return;
            }
        }
    }
}
