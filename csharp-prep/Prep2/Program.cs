using System;

class Program
{
    static void Main(string[] args)
    
  
    {
        //Declaring variable called myGrade
        string myGrade;
        //ask the user for the their grade
        Console.Write("Enter your Grade: ");
        
         myGrade = Console.ReadLine();
        int grade = int.Parse(myGrade);
        //Conditional Statements for Grades
        string letter;
        if(grade>=90){
            letter = "A";
        }
        else if(grade>=80)
            letter = "B";
        else if(grade>=70){
            letter = "C";
        }

        else if(grade>=60){
            letter = "D";
        }
        else{
            letter = "F";
        }
       
        int lastNumber = grade%10;
        string sign ="";
        if(letter!="A"&&letter!="F");
            if(lastNumber>=7){
                sign = "+";
            }
            else if(lastNumber<3){
                sign ="-";
            }
            else if(letter=="A"&&lastNumber<3){
                sign="-";
            }
             if(grade>=90||grade>=70){
            Console.Write($"Congratulations you have passed the class successfully,");
            }
        else{
            Console.Write($"You can do it, try again next Semester,");
            }
            Console.Write($" Your Grade is {letter}{sign}");

    }
    
        
}

    