using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WinForms.MainForm;

namespace WinForms
{
    public partial class FilmForm : Form
    {
        private Film _film;

        // Konstruktor przyjmujący obiekt Film jako argument
        public FilmForm(Film film)
        {
            InitializeComponent();
            _film = film;

            // Przykład: Wyświetlenie informacji o filmie na formularzu
        }
    }
}
