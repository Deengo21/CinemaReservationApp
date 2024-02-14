using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WinForms
{
    public partial class MainForm : Form
    {
        private BindingSource bindingSource1;

        public MainForm()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy, HH:mm";
            InitializeDataGrid();
        }

        public class Film
        {
            public int Id { get; set; }
            public string Tytul { get; set; }
            public DateTime Godzina { get; set; }
            public int Miejsca { get; set; }
        }

        private List<Film> filmy = new List<Film>
        {
            new Film { Id = 1, Tytul = "Incepcja", Godzina = new DateTime(2024, 1, 22, 18, 0, 0), Miejsca = 150 },
            new Film { Id = 2, Tytul = "Interstellar", Godzina = new DateTime(2024, 1, 22, 20, 0, 0), Miejsca = 120 },
        };

        private void InitializeDataGrid()
        {
            // Utwórz DataTable i dodaj kolumny
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Tytuł", typeof(string));
            dataTable.Columns.Add("Godzina", typeof(DateTime));
            dataTable.Columns.Add("Miejsca", typeof(int));

            // Dodaj wiersze do DataTable z danymi o filmach
            foreach (var film in filmy)
            {
                DataRow row = dataTable.NewRow();
                row["ID"] = film.Id;
                row["Tytuł"] = film.Tytul;
                row["Godzina"] = film.Godzina;
                row["Miejsca"] = film.Miejsca;
                dataTable.Rows.Add(row);
            }

            // Ustaw źródło danych dla kontrolki DataGrid za pomocą BindingSource
            bindingSource1 = new BindingSource();
            bindingSource1.DataSource = dataTable;

            dataGridView1 = new DataGridView();
            dataGridView1.DataSource = bindingSource1;

            // Dodaj kolumnę z linkiem do DataGridView
            DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
            linkColumn.HeaderText = "Szczegóły";
            linkColumn.UseColumnTextForLinkValue = true;
            linkColumn.LinkBehavior = LinkBehavior.SystemDefault;
            linkColumn.Text = "Szczegóły";
            dataGridView1.Columns.Add(linkColumn);

            // Ustaw wygląd LinkLabel w ostatniej kolumnie
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;

            // Dodaj kontrolkę DataGridView do formularza
            Controls.Add(dataGridView1);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obsługa kliknięcia w link w ostatniej kolumnie
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Szczegóły"].Index)
            {
                Film film = filmy[e.RowIndex];
                FilmForm filmForm = new FilmForm(film);
                filmForm.ShowDialog();
            }
        }
    }
}
