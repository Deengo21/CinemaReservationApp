using FrontEnd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class MainForm : Form
    {
        public List<Movie> Movies { get; set; }
        public MainForm()
        {
            Movies = GetMovies();
            InitializeComponent();
            InitializeDataGridView();
        }

        private List<Movie> GetMovies()
        {
            var list = new List<Movie>();
            list.Add(new Movie()
            {
                MovieID = 1,
                Title = "Title1",
                RoomID = 1,
                Date = new DateTime(2024, 6, 10, 15, 00, 00)

            });
            list.Add(new Movie()
            {
                MovieID = 2,
                Title = "Title2",
                RoomID = 2,
                Date = new DateTime(2024, 6, 10, 15, 00, 00)

            });
            list.Add(new Movie()
            {
                MovieID = 3,
                Title = "Title3",
                RoomID = 3,
                Date = new DateTime(2024, 6, 10, 15, 00, 00)

            });
            return list;
        }
        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = Movies;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedMovie = dataGridView1.SelectedRows[0].DataBoundItem as Movie;
                textBoxMovieID.Text = selectedMovie.MovieID.ToString();
                textBoxTitle.Text = selectedMovie.Title;
                textBoxRoomID.Text = selectedMovie.RoomID.ToString();
                textBoxDate.Text = selectedMovie.Date.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
    }
}
