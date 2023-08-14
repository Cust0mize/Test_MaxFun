# Test_MaxFun
Геймплей https://youtu.be/d_lkoxvHLMM

Задача:сделать техническое демо игры [GALCON.](https://www.youtube.com/watch?v=UxbJJfshYLM)
НЕ нужно делать полный клон этой игры, достаточно реализовать
следующие механики:

1. Игровой экран с планетами (на планетах производятся кораблики,
отображается числом)
2. Карта генерируется случайно, при этом планеты расположены друг от друга на
расстоянии не менее чем сумма радиусов соседних планет
3. На старте игроку выдается под управление одна планета (случайная,
окрашивается в синий цвет) с 50 кораблями на ней. Корабли на планете игрока
непрерывно производятся со скоростью 5 кораблей/сек.
4. Выделение планеты игрока нажатием
5. По клику на нейтральную планету – 50 процентов кораблей вылетают из
выбранной планеты игрока и атакуют нейтральную
6. При движении кораблики должны облетать планеты встречающиеся на пути
7. Если сумма долетевших до нейтральной планеты кораблей больше числа
кораблей на планете, то планета считается захваченой (окрашивается в цвет
игрока и передается под его управление)
8. Для визуализации можно использовать любые примитивы или изображения из
открытых источников.

Старайтесь избегать чрезмерно объемного использования сторонних плагинов, ограничиваясь функционалом, предоставляемым Unity. Если вы, все же, решите
добавить таковые в тестовое задание, их использование должно быть оправдано (ускорит процесс создания проекта, позволит выполнить больше дополнительных пунктов). 
В особенности не рекомендуется использовать плагины для организации архитектуры проекта (Zenject, Unity.Entities, etc). На задание отводится максимум 2 рабочих дня 
(16 продуктивных часа) Будет плюсом, если вы успеете дополнительно реализовать следующие фичи:

1. Групповое выделение планет как в оригинале
2. Оппонента (бота)
3. Используете ScriptableObject (например, для передустановки сложности, кол-
ва планет и др)
4. Используете при написании игры Editor-скрипты для возможности настройки
параметров игры с их помощью
