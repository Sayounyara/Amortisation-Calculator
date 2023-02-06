using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amortisation
{
    internal class Interest
    {
        //                                |amount borrowed
        //                                |                 |repayment amount
        //                                |                 |               |number of payments
        //                                |                 |               |         |frequency of payments
        //                                |                 |               |         |    (1, 4, 12, 52)
        public static double calculateRate(double principal, double payment, int term, int paymentFrequency)
        {
            const double tolerableError = 0.00001;
            double currentGuess = 0.05 / 12;
            double oldGuess = 0;

            for (int i = 0; i < 20; i++)
            {
                oldGuess = currentGuess;
                currentGuess = currentGuess - f(currentGuess, principal, payment, term) / fPrime(currentGuess, principal, term);
                double guessDifference = Math.Abs(currentGuess - oldGuess);
                if (guessDifference < tolerableError)
                {
                    break;
                }
            }

            return currentGuess;

            /*
             i = 0
        while i < 20:
            updateGuess = guess
            guess = updateGuess - f(updateGuess) / f_prime(updateGuess)
            guessDifference = abs(guess - updateGuess)
            if guessDifference < tolerableError:
                break
            i += 1

        interest_rate = ((guess * payment_frequency * 10000) / 100)*/
        }

        private static double f(double x, double principal, double payment, int term)
        {
            return principal * x * Math.Pow(1 + x, term) / (Math.Pow(1 + x, term) - 1) - payment;
        }

        private static double fPrime(double x, double principal, int term)
        {
            //return principal 
            return principal * (Math.Pow(1 + x, term) / (-1 + Math.Pow(1 + x, term)) -
                           term * x * Math.Pow(1 + x, -1 + 2 * term) /
                           Math.Pow(-1 + Math.Pow(1 + x, term), 2) +
                           term * x * Math.Pow(1 + x, -1 + term) /
                           (-1 + Math.Pow(1 + x, term)));
        }
        /*
         loan_amount = 38070.00   #value is an example. This is the amount borrowed and needs to be input by user
        payment_amount = 730.35  #value is an example. This is the repayment amount and needs to be input by user
        number_of_payments = 60  #value is an example. The is the number of repayments (in this case 5 years, monthly payment)
        payment_frequency = 12   #value is an example. How many payments in the year (1 = yearly, 12 = monthly)
        
        tolerableError = float(10 ** -5)
        guess = float(0.05 / 12)
        updateGuess = float(0)
        
        def f(x):
            return loan_amount * x * ((1 + x) ** number_of_payments) / (((1 + x) ** number_of_payments) - 1) - payment_amount
        
        
        def f_prime(x):
            return principal * (((1 + x) ** term) / (-1 + ((1 + x) ** term)) -
                          term * x * ((1 + x) ** (-1 + 2 * term)) /
                          ((-1 + ((1 + x) ** term)) ** 2) +
                          term * x * ((1 + x) ** (-1 + term)) /
                          (-1 + ((1 + x) ** term)))


        
        print(f"Interest Rate is {interest_rate:.2f}%")
        print(guess)  # this figure is what is used for the interest rate on the amortisation schedule
         */
    }
}
