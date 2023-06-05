﻿using OVB.Demos.Libraries.Application.Interfaces;
using OVB.Demos.Transports.CompanyContext.Application.UseCases.BatchImportCompanies.Inputs;
using OVB.Demos.Transports.CompanyContext.Application.UseCases.BatchImportCompanies.Outputs;
using OVB.Demos.Transports.Responses;

namespace OVB.Demos.Transports.CompanyContext.Application.UseCases.BatchImportCompanies;

public sealed class BatchImportCompaniesUseCase : IUseCase<BatchImportCompaniesUseCaseInput, ResponseBase<BatchImportCompaniesUseCaseSuccessfullResponse>>
{
    public Task<ResponseBase<BatchImportCompaniesUseCaseSuccessfullResponse>> ExecuteUseCaseAsync(BatchImportCompaniesUseCaseInput input, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}