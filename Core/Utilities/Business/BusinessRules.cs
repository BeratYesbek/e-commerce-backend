using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult run(params IResult[] logics)
        {
            foreach (var item in logics)
            {
                if (!item.Success)
                {
                    return item;
                }
            }

            return new SuccessResult();
        }
    }
}
