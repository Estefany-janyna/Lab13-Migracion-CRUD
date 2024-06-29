namespace sem13.Roles
{
    public static class ValidationHelper
    {

        public static UserValidationResult GetRole(string username, string password)
        {
            UserValidationResult validationResult = new UserValidationResult();

            if (username == "admin" && password == "admin123")
            {
                validationResult.IsValid = true;
                validationResult.Role = "Administrator";
            }
            else if (username == "superuser" && password == "superuser123")
            {
                validationResult.IsValid = true;
                validationResult.Role = "SuperUser";
            }
            else if (username == "invited" && password == "invited123")
            {
                validationResult.IsValid = true;
                validationResult.Role = "Invited";
            }
            else
            {
                validationResult.IsValid = false;
                validationResult.Role = "User";
            }

            return validationResult;
        }

    }
}
