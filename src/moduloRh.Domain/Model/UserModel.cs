﻿namespace moduloRh.Domain.Model
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //TODO: Adicionar Status
    }
}
