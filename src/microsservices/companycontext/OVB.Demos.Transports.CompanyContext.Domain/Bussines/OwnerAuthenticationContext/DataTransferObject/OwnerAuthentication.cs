﻿using OVB.Demos.Libraries.Domain;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerContext.DataTransferObject;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerAuthenticationContext.DataTransferObject;

public sealed class OwnerAuthentication : DataTransferObjectBase.All
{
    public OwnerAuthentication(string email, string username, string password, bool isEmailConfirmed, bool isActivatedAccess, 
        Guid identifier, Guid correlationIdentifier, string sourcePlatform, DateTime createdAt, DateTime updatedAt) 
        : base(identifier, correlationIdentifier, sourcePlatform, createdAt, updatedAt)
    {
        Email = email;
        Username = username;
        Password = password;
        IsEmailConfirmed = isEmailConfirmed;
        IsActivatedAccess = isActivatedAccess;
    }

    #region Properties

    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public bool IsActivatedAccess { get; set; }

    #endregion

    #region Relationships

    public Guid? OwnerIdentifier { get; set; }
    public Owner? Owner { get; set; }

    #endregion
}