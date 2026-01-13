namespace NotesApp.Views;

public partial class NotePage : ContentPage
{
	string _filename = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

	public NotePage()
	{
		InitializeComponent();

		string appDataPath = FileSystem.AppDataDirectory;
		string randomFileName = $"{Path.GetRandomFileName()}";

		LoadNote(Path.Combine(appDataPath,randomFileName));
	}

	private void LoadNote(string filename)
	{
		Models.Note noteModel = new Models.Note();
		noteModel.Filename = filename;

		if (File.Exists(_filename))
		{
			noteModel.Date = File.GetCreationTime(filename);
			noteModel.Text = File.ReadAllText(filename);
		}

		BindingContext = noteModel;
	}

	private void SaveButton_Clicked(object sender, EventArgs e)
	{
		File.WriteAllText(_filename, TextEditor.Text);
	}

	private void DeleteButton_Clicked(Object sender, EventArgs e)
	{
		if (File.Exists(_filename))
			File.Delete(_filename);

		TextEditor.Text = string.Empty;
	}
}