
namespace DIO.Series
{
    public class Serie : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }


        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public string ToString()
        {
            string output = "";
            output += "Genre: " + this.Genre + Environment.NewLine;
            output += "Title: " + this.Title + Environment.NewLine;
            output += "Description: " + this.Description + Environment.NewLine;
            output += "Year of Start: " + this.Year + Environment.NewLine;
            output += "Deleted: " + this.Deleted + Environment.NewLine;

            return output;
        }

        public string ReturnTitle()
        {
            return this.Title;
        }

        public int ReturnId()
        {
            return this.Id;
        }

        public bool returnDeleted()
        {
            return this.Deleted;
        }

        public void TurnDeleted()
        {
            this.Deleted = true;
        }
    }
}