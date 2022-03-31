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

let FunctionSelection a b =
    match a with 
    |1 -> SumOfPrimeDiv b
    |2 -> NumberOfOddDig b
    |_ -> ProductOfDiv b

[<EntryPoint>]
let main argv =
    System.Console.WriteLine("Введите номер функции и аргумент:
    1 - Сумма простых делителей числа 
    2 - Количество нечетных цифр числа, которые больше 3 
    _ - Произведение делителей числа, сумма цифр которых меньше суммы цифр исходного числа 
    ")
    let n = (Console.ReadLine() |> Int32.Parse, Console.ReadLine() |> Int32.Parse)
    let a = (fst n)
    let b = (snd n)
    let result = FunctionSelection a b
    System.Console.WriteLine("Результат:{0}",result)
    0 