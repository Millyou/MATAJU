using System.ComponentModel;

public class USER : INotifyPropertyChanged
{
    private string? id;
    private string? password;
    private string? passwordConfirm;
    private string? nickname;

    public string? ID
    {
        get => id;
        set
        {
            if (id != value)
            {
                id = value;
                OnPropertyChanged(nameof(ID));
            }
        }
    }

    public string? Password
    {
        get => password;
        set
        {
            if (password != value)
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
    }

    public string? PasswordConfirm
    {
        get => passwordConfirm;
        set
        {
            if (passwordConfirm != value)
            {
                passwordConfirm = value;
                OnPropertyChanged(nameof(PasswordConfirm));
            }
        }
    }

    public string? Nickname
    {
        get => nickname;
        set
        {
            if (nickname != value)
            {
                nickname = value;
                OnPropertyChanged(nameof(Nickname));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
