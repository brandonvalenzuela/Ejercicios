using RickAndMortyApi.Controllers;
using RickAndMortyApi.Models;
using System.Net.Http;


namespace RickAndMortyApi
{
    public partial class Form1 : Form
    {
        private CharactersController charactersController;
        private CharactersList charactersList;

        public Form1()
        {
            InitializeComponent();
            charactersController = new CharactersController();
            charactersList = new CharactersList();
        }

        private async void GetCharacters()
        {
            charactersList = await charactersController.GetAllCharacters();

            if (charactersList != null)
            {
                foreach (var characters in charactersList?.results!)
                {
                    DataGridViewRow row = new();
                    row.CreateCells(dgvCharacters);

                    row.Cells[0].Value = characters.Name;
                    row.Cells[1].Value = characters.Status;
                    row.Cells[2].Value = characters.Gender;
                    row.Cells[3].Value = characters.Species;
                    row.Cells[4].Value = characters?.Origin?.Name;

                    dgvCharacters.Rows.Add(row);

                }
            }
            else
            {
                MessageBox.Show("No se pudo optener la petición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetCharacters();
        }
    }
}