# Многокритериальная оптимизация: метод идеальной точки
Задача многокритериальной оптимизации сводится к следующей задачи однокритериальной оптимизации:
<!--- ![equation](http://latex.codecogs.com/gif.latex?min%5C%3Ad%28x%29%20%3D%20%5Csqrt%7B%5Csum_%7Bi%3D1%7D%5E%7Bm%7D%28f_%7Bi%7D%28x%29-f_%7Bi%7D%5E%7B*%7D%29%5E%7B2%7D%7D)<br> -->
![equation](http://latex.codecogs.com/gif.latex?min%5C%3Ad%28x%29%20%3D%20%5Csum_%7Bi%3D1%7D%5E%7Bm%7D%28f_%7Bi%7D%28x%29-f_%7Bi%7D%5E%7B*%7D%29%5E%7B2%7D)<br>
![equation](http://latex.codecogs.com/gif.latex?x%5Cepsilon%20X)<br>
где ![equation](http://latex.codecogs.com/gif.latex?f_i%28x%29) – частные критерии,  ![equation](http://latex.codecogs.com/gif.latex?f_i%5E*) - числовой вектор оптимальных значений на множестве X по каждому частному критерию, i = 1...m<br>
Область ограничений X и частные критерии определены линейными функциями.<br>
Для решения данной задачи используется метод внешных штрафных функций со следующей функцией штрафа:<br>
![equation](http://latex.codecogs.com/gif.latex?P%28x%2Ck%29%20%3D%5Calpha%20_%7Bk%7D%5Csum_%7Bi%3D1%7D%5E%7Br%7D%28max%5Cleft%20%5C%7Bg_%7Bi%7D%28x%29%3B0%20%5Cright%20%5C%7D%29%5E%7B2%7D&plus;%5Csum_%7Bi%3Dr&plus;1%7D%5E%7Bn%7D%5Cleft%20%7C%20g_%7Bi%7D%28x%29%20%5Cright%20%7C%5E%7B2%7D)<br>
![equation](http://latex.codecogs.com/gif.latex?%5Calpha%20_%7Bk%7D) - возрастающая последовательность, k - номер итерации<br>
Тогда на k-ом шаге метода штрафных функций задача безусловной оптимизации имеет вид:
![equation](http://latex.codecogs.com/gif.latex?F_%7Bk%7D%28x%29%20%3D%5Csum_%7Bi%3D1%7D%5E%7Bm%7D%28f_%7Bi%7D%28x%29-f_%7Bi%7D%5E%7B*%7D%29%5E%7B2%7D&plus;%5Calpha%20_%7Bk%7D%5Csum_%7Bi%3D1%7D%5E%7Br%7D%28max%5Cleft%20%5C%7Bg_%7Bi%7D%28x%29%3B0%20%5Cright%20%5C%7D%29%5E%7B2%7D&plus;%5Csum_%7Bi%3Dr&plus;1%7D%5E%7Bn%7D%5Cleft%20%7C%20g_%7Bi%7D%28x%29%20%5Cright%20%7C%5E%7B2%7D)<br>
Для ее решения используется метод наискорейшего спуска с использованием метода деления отрезка пополам для нахождения полного шага.
