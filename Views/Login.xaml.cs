using Microsoft.Win32;

namespace jcevallosExame.Views;

public partial class Login : ContentPage
{
    private Dictionary<string, string> usuarios = new()
        {
            { "estudiante2025", "moviles" },
            { "uisrael", "2025" },
            { "sistemas", "2025_1" }
        };

    public Login()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string usuario = entryUsuario.Text;
        string password = entryPassword.Text;

        if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Por favor, ingrese usuario y contraseña", "OK");
            return;
        }

        if (usuarios.TryGetValue(usuario, out string valor) && valor == password)
        {
            await Navigation.PushAsync(new Registro(usuario)); // Clase "Registro"
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
        }
    }

    private async void OnAcercaDeClicked(object sender, EventArgs e)
    {
        string usuario = entryUsuario.Text?.Trim();

        if (string.IsNullOrEmpty(usuario))
        {
            await DisplayAlert("Error", "Debe ingresar un usuario para continuar", "OK");
            return;
        }

        await Navigation.PushAsync(new AcercaDe(usuario));
    }
}
