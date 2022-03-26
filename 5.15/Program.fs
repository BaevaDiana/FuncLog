open System
//Взаимно простые числа — целые числа, не имеющие никаких общих делителей, кроме ±1
//Два целых числа a и b называются взаимно простыми, если их наибольший общий делитель равен единице
 
let rec F1 a b =
    if a=b then a
    else 
        if a>b then F1 (a-b) b 
        else F1 a (b-a) 
 
let obxod x F init =
    let rec obxod1 x F init chislo =
        if chislo=0 then init
        else 
            let new_init = if (F1 x chislo) =1 then F init chislo else init
            let new_chislo= chislo - 1
            obxod1 x F new_init new_chislo
    obxod1 x F init x
 
 
[<EntryPoint>]
let main argv =
    System.Console.WriteLine("Введите число:")
    let x = System.Convert.ToInt32(System.Console.ReadLine())
    System.Console.WriteLine("Сумма:{0}", obxod x (fun x y -> x+y) 0)
    0 
 
