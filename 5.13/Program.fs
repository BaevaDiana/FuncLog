open System

//Рекурсии вверх
//Произведение цифр
let rec pr_v x =
    match x with
    |x when x<>1->(x%10)*(pr_v(x/10))
    |x->1
 
 //Максимальная цифра
let rec max_v x =
    match x with
    |x when x<10-> x
    |x->max (x % 10) (max_v (x/10))
 
// Минимальная цифра
let rec min_v x =
    match x with
    |x when x<10-> x
    |x->min (x % 10) (min_v (x/10))
 
//Рекурсии вниз
//Произведение цифр
let rec pr x a =
    match x with 
    | x when x=0 ->a
    | x->pr(x/10)a*(x%10)
 
//Максимальная цифра
let rec max x a =
     match x with 
    |x when (x%10)>a->max(x/10)(x%10)
    |x when x=0 ->a
    |x->max(x/10)a
 
//Минимальная цифра
let rec min x a =
     match x with 
    | x when (x<>0)&&((x%10)<a)->min(x/10)(x%10)
    |x when x=0 ->a
    | x->min(x/10)a
 
 
[<EntryPoint>]
let main argv =
    System.Console.WriteLine("Введите число:")
    let x = System.Convert.ToInt32(System.Console.ReadLine())
    System.Console.WriteLine("Рекурсии вверх:{0}")
    System.Console.WriteLine("Произведение:{0}", pr_v x)
    System.Console.WriteLine("Максимум:{0}", max_v x)
    System.Console.WriteLine("Минимум:{0}", min_v x)
    System.Console.WriteLine("Рекцурсии вниз:{0}")
    System.Console.WriteLine("Произведение:{0}", pr x 1)
    System.Console.WriteLine("Максимум:{0}", max x 0)
    System.Console.WriteLine("Минимум:{0}", min x 9)
    0 