# DrawGraphs





# 1. Објаснување на апликацијата
  DrawGraphs е едукативна апликација која му овозможува на корисникот визуeлизација на работата на едни од најпознатите алгоритми
  кои се користат во програмирањето. Притоа, корисникот може произволно да си креира свој граф, и врз соодветниот граф да избере
  алгоритам со кој што сака да го измине графот.
  ## 1.1 Функционалности на апликацијата
  Апликацијата DrawGraphs има две главни функционалности, првата функционалност му овозможува на корисникот исцртување на тежински
  и безтежински графови, додека пак втората функционалност е врз база на видот на нацртаниот граф да му предложи алгоритам кој
  може да се искористи за изминување на соодветниот граф. Апликацијата овозможува прикажување на следните четири алгоритми:
- 	*Пребарување по длабочина (анг: Depth-first search)* - овој алогиритам цели да отиде што е можно подлабоко во графот пред да почне да се враќа наназад. Употребата на овој алгоритам е овозможена само врз нетежински графови
- 	*Пребарување по широчина (анг: Breadth-first search)* - овој алгоритам го изминива графот ниво по ниво, почнувајќи од еден јазел ги посетува сите негови соседи, па соседите на соседите итн. Употребата на овој алгоритам исто така е овозможена само врз нетежински графови
- 	*Алгоритамот на Дијкстра* - од произволно избрано теме во тежински граф, алгоритамот на Дијкстра ги наоѓа најкратките патишта од тоа теме до сите останати
-   *Алгоритамот на Прим* - овој алгоритам се користи врз тежински граф, неговата цел е од графот да формира минимално скелетно дрво. 
## 1.2 Упатство на употреба на апликацијата
Апликацијата е доста едноставна за користење. Откако ќе се стартува апликацијата се отвара Home формата која се состои од две копчиња. Home формата е прикажана на следната слика:

![alt text](https://github.com/Vilijan/DrawGraphs/blob/master/Home_form.jpg)
                                        


Со притискање на некое од копчињата Draw Weighted Graph или Draw Unweighted Graph се отварана нова форма која овозможува цртање на соодветниот тип на граф. Формата за цртање на Weighted Graph е прикажана на следната слика:

![alt text](https://github.com/Vilijan/DrawGraphs/blob/master/WeightedGraph_form.jpg)
                                        

## 1.2.1 Цртање на граф
Откако ќе се отвори формата за цртање на граф, во неа јасно е обележана бела површина која е затворена со црни рабови. Само во оваа рамка може да се цртаат јазли. Со едноставно кликање на оваа повшина се креираат јазли во вид на кругчиња. Бројот на јазли не е ограничен, но не е дозволено да се креираат два јазли чии кругови ќе се сечат. Видови на јазли:
-	*црн јазол* - овој е најобичен јазол, при изминување на графот со некој од алгоритмите црниот јазол означува непосетен јазол
-	*црвен јазол* - во даден момент може да има најмногу само еден ваков јазол, црвената боја ни претставува дека јазол ни е селектиран. 
-	*зелен јазол* - овој јазол се појавува за време на извршување на некој од алгоритмите. Ваквата боја ни претставува дека тој јазол ни е веќе посетен од страна на алгоритамот

Креирање на раб во графот се врши на тој начин што прво треба да селетираме некој јазол и истиот јазол ќе ја смени бојата од црна во црвена. Селектирањето се врши со mouse-click врз некој од црните јазли. Откако сме селектирале јазол, со уште еден клик врз некој од преостанатите црни јазли додаваме раб помеѓу слектираниот јазол и последниот црн јазол кој што сме го кликнале. Доколку додаваме јазол во тежински граф ќе се појави нов прозорец во кој што треба да ја внесеме тежината. Тежината мора да биде природен број кој има најмногу три цифри.
## 1.2.2 Стартување на алгоритам, употреба на копчето Start
За да можеме да стартуваме алгоритам потребно е претходно да исполниме неколку услови. Во горниот лев ќош има два combo-boxes кои служат за избор на соодветниот алгоритам и брзината на изминување на јазлите. Во првиот combo-box треба да се селектира алгоритамот кој што сакаме да го употребиме. Вториот combo-box ни ја претставува брзината, брзината е претставена како node/ms односно за колку милисекунди алгоритамот ќе изминува еден јазол. Исто така за да го стартуваме алгоритамот потребно ни е да иаме селектирано еден јазол кој ќе го означува од каде ќе почне алгоритамот. Доколку се исполнети овие три услови ќе се овозможи притискање на копчето Start. За време на извршување на алгоритамот не е дозволено креирање на нови јазли.
## 1.2.3 Објаснување на копчињата Reset,Clear и Delete
-   *Reset* - ова копче може да се употреби откако сме извршиле некој алгоритам, притоа сите јазли ќе станат црни(непосетени) и ќе може одново да се искористи алгоритам врз нацртаниот граф
- 	*Clear* - ова копче ни ги брише сите нацртани јазли и рабови, при што треба да почнеме одново со цртање на графот
- 	*Delete* - за употреба на ова копче потребно е да имаме селектирано јазол, селектираниот јазол и сите рабови кои се поврзани со него се бришат
# 2.  Опис на изработката на апликациајта
  Во рамките на оваа апликација употребени се повеќе класи и исто така повеќе разновидни податочни структури при употреба на алгоритмите. За имплементација на алгоритамот "Пребарување по длабочина " се користи податочна струткура магацин, за "Пребарување по ширина" се користи ред, додека за aлгоритмите на Дијкстра и Прим се користи приоритетен ред.
  
НАПОМЕНА: Кодот за приоритетниот ред во рамките на оваа апликација не е наше дело, превземено е од следниот линк: https://github.com/BlueRaja/High-Speed-Priority-Queue-for-C-Sharp
## 2.1 Опис на најкористените класи
- 	*Node.cs* - оваа класа служи за претставувањето на јазлите. Секој јазол од графот претставува една инстанца од оваа класа
- 	*NodesDoc.cs* - оваа класа служи како главна класа при организација на сите јазли. Во оваа класа се чуваат сите креирани јазли
- 	*UnweightedGraph.cs* - оваа класа ни ја овозможува формата за цртање на нетежински графови. Тука се наоѓаат сите копчиња,алгоритми кои се употребуваат при работењето се нетежински графови
- 	*WeightedGraph.cs* - оваа класа е многу слична на класа UnweightedGraph.cs само што служи при работа со тежински графови
## 2.2 Опис на функцијата dfs
Функцијата dfs во рамките на оваа апликација е имплементирана како EventHandler за главниот тимер. Оваа функција се повикува при секое активирање на тимерот откатко корисникот ќе го избере овој алгоритам и ќе притисне на копчето старт. Изворниот код е прикажан на следната слика:

![alt text](https://github.com/Vilijan/DrawGraphs/blob/master/Dfs_SourceCode.jpg)

*Изработено од:*

**Вилијан Монев 151063**

**Борче Велков 151109**           

