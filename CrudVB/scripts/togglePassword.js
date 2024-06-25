function togglePassword(event) {
    const passwordField = event.target.previousElementSibling;
    const toggleIcon = event.target;
    if (passwordField.type === "password") {
        passwordField.type = "text";
        toggleIcon.textContent = "🙈";
    } else {
        passwordField.type = "password";
        toggleIcon.textContent = "👁️";
    }
}

document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".toggle-password").forEach(function (element) {
        element.addEventListener("click", togglePassword);
    });
});
