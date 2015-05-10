#Hot Dog Bush

Членови на тимот: Мартин Бончаноски, Оливер Орешковски, Емилија Топалзолева 

Проектот е имплементација на играта hot-dog bush која можете да ја видете на следниот линк: http://www.2dplay.com/hot-dog-bush/hot-dog-bush-play.htm . Целта на играта е да се услужат што повеќе гости во рок од една минута и триесет секунди.

##Правила на игра:

Играта се игра само со помош на глувче. 
Можат да дојдат максимум 5 луѓе што порачуваат (секој со своите желби). Додека во исто време максимум можат да се стават три лепчиња и три виршли за подготовка. Како додаток може во сендвичот да има и кечап како и пијалок по желба на гостинот. На крајот од играта (после изминатото време) морате да ги доуслужите дојдените гости за да заврши играта се гледа вашата заработка, ако е доволно висока вие можете да се запишете во листата на 10 најдобри играчи.

##Како се игра:

На почетокот се појавува воведен прозорец. На прозорецот има три копчиња: Play, Instructions, High score. ![Home](http://i.imgur.com/SBDAbCg.jpg)

Kопчето PLAY ви се отвара прозорецот за играње, на сликата е прикажана една слика од играта.![Play](http://i.imgur.com/lwUapaB.jpg)

Kопчето INSTRUCTIONS ве носи во прозорецот каде се опишани правилата на играта. ![instructions](http://i.imgur.com/43xyUIL.jpg)

Копчето HIGH SCORES ви го отвара прозорецот каде се запишани десетте најдобри играчи со нивните поени. ![high-score](http://i.imgur.com/qou9FHp.jpg)

##Опис на класите од кои е составено решението:

###Bread
Класа која ги претставува лепчињата за хот-догот и може да се наоѓа во неколку состојби (да има/нема виршла и кечап)

###ClickObject
Класа која ги претставува лепчињата и виршлите и на нивни клик на масата/скарата соодветно се појавуваат лепчињата/виршлите

###Coins
Класа која ги претставува паричките кои ги остава купувачот

###CustomerPositions
Класа која ги одредува позициите на кои се наоѓаат купувачите или дали некоја позиција е слободна

###Drinks
Ги претставува пијалоците во долниот лев агол, на клик се појавува чаша

###Grill
Ја претставува скарата, односно позициите на кои се наоѓаат виршлите на скарата како и кои позиции се слободни

###Ketchup
Го претставува кечапот, може да се движи и доколку се остави над лепче на лепчето се додава кечап

###Money
Класа која покажува колку пари се добиени/одземени

###Order
Класа која покажува нарачка која еден купувач може да ја изврши, содржи и податоци од што се состои нарачката

###ОrderList
Класа која ги содржи сите можни типови на нарачки

###Person
Класа која покажува еден потрошувач

###PersonList
Класа која ги содржи сите можни луѓе кои можат да се јават како купувачи

###Sausage
Класа која ја претставува виршлата, може да се движи, менува изглед ако е на скарата, ја менува сликата на лепчето доколку е оставена врз него

###Shape
Апстрактна класа од која населдуваат сите објекти кои се исцртуваат со слика 

###ShapeList
Класа која ги содржи сите објекти кои треба да се прикажат на екранот

###Table
Класа која ги содржи позициите на кои се поставуват лепчињата на масата и оние кои се слободни

###Trash
Корпа за отпадоци, доколку се остави некој објект на неа се одзема од добивката

###Water
Класа која ја претставува чашката со вода


###Drawable
Интерфејс кој кажува дека објектот може да се исцрта, односо го имплементира методот Draw


###Опис на еден метод
public override void MouseUp(Shape s)
        {
            if (s is Bread)
            {
                Bread b = (Bread)s;
                if (!b.hasSausage || !order.Sausage || payHotDog)
                    b.MouseUp();
                else
                {
                    payHotDog = true;
                    toPay += b.price;
                    if (b.hasKetchup && order.Ketchup)
                    {
                        payKetchup = true;
                        toPay += Ketchup.price;
                    }
                    else if (order.Ketchup && !b.hasKetchup)
                        toPay -= 2;
                    order.changePicture(b);
                    Game.removeShape(s);
                    Game.table.removeBread(s);

                }
                checkOrderCompleted();
            }
            else
                if (s is Drinks)
                {
                    if (!order.Glass || payWater)
                        s.MouseUp();
                    else
                    {
                        payWater = true;
                        toPay += Water.price;
                        s.MouseUp();
                        order.changePicture(s);
                        checkOrderCompleted();
                    }

                }
                else
                    s.MouseUp();
        }
		
Во овој метод се врши обработка на настанот кога врз еден потрошувач е отпуштен(mouseUp) на некој објект. Се проверува дали тој објект е лепче или чаша со вода.
Доколу е лепче се проверува дали во нарачката на овој потрошувач има хот-дог и ако има да не има случајно веќе добиено хот-дог. Ако нема хот-дог или веќе добил хот-дог тогаш потребно е да го вратиме хот-догот назад на своето место, инаку треба да се додаде на цената што треба да ја плати. Исто се проверува дали има кечап или не.
Доколу е чаша вода тогаш на цената што треба да ја плати се додава цената на чашата со вода и таа исчезнува, инаку само исчезнува без ништо да се додаде.
Доколку не е објект од овој тип потребно е истиот да се врати на својата почетна позиција.
