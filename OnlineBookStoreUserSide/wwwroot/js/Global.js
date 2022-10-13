let ServiceUrl = "https://localhost:44352/";

function RedirectToLogin() {
    localStorage.setItem("message", "Please Login First");
    location.href = '/Home/Index';
}