open System

//Метод 1 - найти сумму простых делителей числа 
let PrimeDiv n = 
    let rec Prime n div = 
        if div = 1 then true
        else 
            if n%div=0 then false
            else 
                let newDiv=div-1
                Prime n newDiv
    Prime n (n-1)

let SumOfPrimeDiv n = 
    let rec SumPrimeD n sumInit div = 
        if div = 1 then sumInit
        else 
            let NextSum=
                if n%div=0 && (PrimeDiv div = true) then sumInit+div
                else sumInit
            let newDiv=div-1
            SumPrimeD n NextSum newDiv
    SumPrimeD n 0 n  

//Метод 2 - найти количество нечетных цифр числа, больших 3
let NumberOfOddDig n = 
    let rec NumberDig n num = 
        if n = 0 then num
        else 
            let nextNum = 
                if (n%10)%2=1 && (n%10)>3 then (num+1)
                else num
            let NextN = n/10
            NumberDig NextN nextNum
    NumberDig n 0

//Метод 3 - найти произведение таких делителей числа, сумма цифр которых меньше сумма цифр исходного числа
let SumOfDig n = 
    let rec SumDig n init = 
        if n = 0 then init
        else 
            let nextInit = init+(n%10)
            let nextN=n/10
            SumDig nextN nextInit
    SumDig n 0

let ProductOfDiv n = 
    let rec ProductDiv n result div = 
        if div = 1 then result
        else 
            let nextRes= 
                if n%div=0 && (SumOfDig div < SumOfDig n) then result*div
                else result
            let nextDiv = div-1
            ProductDiv n nextRes nextDiv
    ProductDiv n 1 n

[<EntryPoint>]
let main argv =
    System.Console.WriteLine("Введите число:")
    let n = System.Convert.ToInt32(System.Console.ReadLine())
    let res1 = SumOfPrimeDiv n
    Console.WriteLine("Сумма простых делителей числа = {0}",res1)
    let res2=NumberOfOddDig n
    Console.WriteLine("Количество нечетных цифр числа, которые больше 3  = {0}",res2)
    let res3=ProductOfDiv n
    Console.WriteLine("Произведение делителей числа, сумма цифр которых меньше суммы цифр исходного числа = {0}",res3)
    0 