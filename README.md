# Turtle Bot

## Déplacements de la tortue :

- `Forward(d)` : fait avancer la tortue de `d`;
- `Backward(d)` : fait reculer la tortue de `d`;
- `Left(a)` : fait pivoter la tortue d’un angle de a degrés vers la gauche;
- `Right(a)` : fait pivoter la tortue d’un angle de a degrés vers la droite.
- `Goto(x,y)` : la tortue va se positionner au point de coordonnées (x,y);
- `Up()` : lève le crayon ;
- `Down()` : baisse le crayon;
- `Pensize(width)` : fixe la largeur du trait (en pixel);
- `Pencolor(c)` : la couleur par défaut est le noir, on peut la changer en mettant une couleur prédéfinie « red », « green », « blue », « yellow »;

__________________________

## Partie 1, un triangle :

### Exercice 1 :

Écrivez un programme qui trace un triangle équilatéral de côté 100.

![Triangle](turtle1-400x289.png)


### Exercice 2 :
Maintenant écrivez une fonction triangle(n) qui dessine un triangle de côté n.
triangle(100) devrait produire le même résultat que dans l’exercice 1.



### Exercice 3 :
Modifiez la fonction précédente, pour obtenir la fonction triangle(angle, n) qui permet de tracer un triangle équilatéral de côté n et d’orientation angle.

Par exemple avec triangle(30, 100) vous devez obtenir :

![Triangle](turtle2-400x304.png)

_________________________________


## Partie 2, des carrées :
### Exercice 1 :
Écrivez une fonction carre(n) qui trace un carre de côté n. La tortue doit terminer son trajet en étant dans la même position qu’au départ.


![Carre](turtle3-400x325.png)

### Exercice 2 :
Écrivez une fonction plusieurs_carres(n) qui permet de tracer n carrés côte à côte. Bien sur, cette fonction doit faire appel à la fonction créer dans l’exercice précédent.
(laissez 10px entre chaque carré)

![Carre](turtle4-1200x355.png)


________________________

## Partie 3, une maison :
### Exercice 1 :

Dessiner la maison suivante :

![Maison](maison.png)



Intéressant: Il est possible de dessiner cette maison sans lever le crayon ni repasser deux fois sur un trait. Pour en savoir plus : Maison de Saint-Nicolas

_______________________

## Partie 4, des triangles et des carrés :
### Exercice 1 :
En vous aidant des deux parties précédentes, écrivez un programme qui produit la figure suivante :

![Ligne Carre Triangle](turtle5-1200x208.png)

### Exercice 2 :
En vous aidant des deux parties précédentes, écrivez un programme qui produit la figure suivante :

 
![Carre Triangle](turtle6-600x564.png)


# Bonus

## Problème de recherche, le flocon de Von Koch :

Cette figure a été imaginée par le mathématicien suédois Niels Fabian Helge von
Koch, afin de montrer que l’on pouvait tracer des courbes continues en tout point, mais dérivables en
aucun.
Le principe est simple : on divise un segment initial en trois morceaux, et on construit un triangle
équilatéral sans base au-dessus du morceau central. On réitère le processus n fois, n étant appelé
l’ordre.

Voici ce que cela donne aux ordres 0, 1, 2 et 3 :

![Flocon 1](flocon1-1200x121.png)

Si on trace trois fois cette figure, de façon à la refermer on obtient :

![Flocon 3+2](flocon2-1200x304.png)

## Exercice 1 :
Écrivez une fonction koch_0(l) qui trace l’ordre 0 et koch_1(l) qui trace l’ordre 1.



## Exercice 2 :
Écrire la fonction koch_n(l, n) qui trace l’ordre n.
