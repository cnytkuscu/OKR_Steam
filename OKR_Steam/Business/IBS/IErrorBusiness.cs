﻿using OKR_Steam.Models.ResponseModels;

namespace OKR_Steam.Business.IBS
{
    public interface IErrorBusiness
    {
        public void Insert(ErrorModel error);
    }
}
