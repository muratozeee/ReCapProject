
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {

            //it can not be empty
            RuleFor(p => p.CarName).NotEmpty();
            //We added the Car Name minimum 2 letter...
            RuleFor(p => p.CarName).MinimumLength(2);
            //UnitPrice can not empty..!
            RuleFor(p => p.DailyPrice).NotEmpty();
            //UnitPrice has to be greater than 0
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            //Let's do it relational database it means foreign keys....
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(1000).When(p => p.BrandId == 3);

            //Start with T forexample.
            RuleFor(p => p.CarName).Must(StartWithT).WithMessage("Cars have to start with T letter..!");
            

           
        }

        private bool StartWithT(string arg)
        {
            return arg.StartsWith("T");
        }
    }
}
