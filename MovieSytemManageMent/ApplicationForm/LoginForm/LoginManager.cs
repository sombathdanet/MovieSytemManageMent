// ============================================================
// FILE: ApplicationForm/LoginForm/LoginManager.cs
// PATTERNS: Singleton + Factory
// ============================================================
using System;
using System.Collections.Generic;

namespace MovieSytemManageMent.ApplicationForm.LoginForm
{
    // ── Singleton Login Manager ───────────────────────────────────────────
    public class LoginManager
    {
        private static LoginManager _instance;
        private LoginManager()
        {
            // Seed default admin on first load
            _users["admin"] = new AdminUser("admin", "123");
        }

        public static LoginManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LoginManager();
                return _instance;
            }
        }

        // ── In-memory user store ──────────────────────────────────────────
        private readonly Dictionary<string, IUser> _users
            = new Dictionary<string, IUser>(StringComparer.OrdinalIgnoreCase);

        // ── Factory: create and register a new user ───────────────────────
        public bool CreateUser(string username, string password)
        {
            username = username.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
                return false;

            // Don't overwrite existing users
            if (_users.ContainsKey(username))
                return false;

            _users[username] = new AdminUser(username, password);
            return true;
        }

        // ── Check if username already exists ──────────────────────────────
        public bool UserExists(string username)
            => _users.ContainsKey(username.Trim().ToLower());

        // ── Login logic ───────────────────────────────────────────────────
        public bool Login(string username, string password)
        {
            username = username.Trim().ToLower();
            if (!_users.TryGetValue(username, out IUser user))
                return false;
            return user.ValidatePassword(password);
        }
    }

    // ── User Interface ────────────────────────────────────────────────────
    public interface IUser
    {
        string Username { get; }
        bool ValidatePassword(string password);
    }

    // ── Concrete User (Admin) — password stored per instance ─────────────
    public class AdminUser : IUser
    {
        private readonly string _password;

        public string Username { get; }

        public AdminUser(string username, string password)
        {
            Username = username;
            _password = password;
        }

        public bool ValidatePassword(string password)
            => _password == password;
    }
}