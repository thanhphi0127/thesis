// Hanoi_4Coc.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "conio.h"
#include "stdio.h"
#include "iostream"
using namespace std;

void Hanoi5(int, int, int, int, int, int, int);
void Hanoi4(int, int, int, int, int, int);
void Hanoi3(int, int, int, int);
int sochia(int);
int solan = 0;

int arrayPascal[] = {0, 0, 1, 3, 6, 10, 15, 21};
int arrayPascal5[] = {0, 0, 0, 1, 4, 10, 20, 35};

int _tmain(int argc, _TCHAR* argv[])
{
	int sodia = 0;
	int a;
	printf("Thap Ha Noi 4 coc\n");

	Hanoi5(10, 5, 1, 5, 2, 3, 4);

	cout << "SO LAN CHUYEN: "<< solan;
	cin >> a;
	
	return 0;
}

int sochia_i(int n)
{
	return (n - (sqrt(2*n) + 0.5));
}
int sochia(int n)
{
	int l = 0;
	for(int i = 0; i <= 7 ; i++)
	{
		if(n == arrayPascal[i])
		{
			l = n - (i - 1);
			return l;
		}

		if(n < arrayPascal[i])
		{
			return (n - i + 2);
		}

	}
	return l;
}

int sochia5(int n)
{
	int l = 0;
	for(int i = 0; i <= 7 ; i++)
	{
		if(n == arrayPascal5[i])
		{
			l = n - (i - 1);
			return l;
		}

		if(n < arrayPascal[i])
		{
			return (n - i + 2);
		}

	}
	return l;
}

void Hanoi5(int n, int socot, int cotnguon, int cotdich, int trunggian1, int trunggian2, int trunggian3)
{
	if(n == 1)
	{
		cout << "Move " << cotnguon << " to3 " << cotdich << endl;
		solan += 1;
		return;
	}
	if (n == 2)
	{
		cout << "Move " << cotnguon << " to3 " << trunggian1 << endl;
		cout << "Move " << cotnguon << " to3 " << cotdich << endl;
		cout << "Move " << trunggian1 << " to3 " << cotdich << endl;
		solan += 3;
		return;
	}
	
	if (n == 3)
	{
		cout << "Move " << cotnguon << " to3 " << trunggian1 << endl;
		cout << "Move " << cotnguon << " to3 " << trunggian2 << endl;
		cout << "Move " << cotnguon << " to3 " << cotdich << endl;
		cout << "Move " << trunggian2 << " to3 " << cotdich << endl;
		cout << "Move " << trunggian1 << " to3 " << cotdich << endl;
		solan += 5;
		return;
	}
	
	if (n == 4)
	{
		cout << "Move " << cotnguon << " to3 " << trunggian1 << endl;
		cout << "Move " << cotnguon << " to3 " << trunggian2 << endl;
		cout << "Move " << cotnguon << " to3 " << trunggian3 << endl;
		cout << "Move " << cotnguon << " to3 " << cotdich << endl;
		cout << "Move " << trunggian3 << " to3 " << cotdich << endl;
		cout << "Move " << trunggian2 << " to3 " << cotdich << endl;
		cout << "Move " << trunggian1 << " to3 " << cotdich << endl;
		solan += 7;
		return;
	}

	//Buoc 1
	//Xac dinh so chia toi uu trong tam giac Pascal
	int l = sochia5(n);
	cout << "SO CHIA TOI UU 5 L = " << l << endl;


	Hanoi5(l, 4, cotnguon, trunggian1, trunggian2, cotdich, trunggian3);
	Hanoi4(n - l, 4, cotnguon, cotdich, trunggian2, trunggian3);
	Hanoi5(l, 4, trunggian1, cotdich, trunggian2, cotnguon, trunggian3);
	
}

void Hanoi4(int n, int socot, int cotnguon, int cotdich, int trunggian1, int trunggian2)
{
	if(n == 1)
	{
		cout << "Move " << cotnguon << " to3 " << cotdich << endl;
		solan += 1;
		return;
	}
	if (n == 2)
	{
		cout << "Move " << cotnguon << " to3 " << trunggian1 << endl;
		cout << "Move " << cotnguon << " to3 " << cotdich << endl;
		cout << "Move " << trunggian1 << " to3 " << cotdich << endl;
		solan += 3;
		return;
	}


	//Buoc 1
	//Xac dinh so chia toi uu trong tam giac Pascal
	int l = sochia(n);
	cout << "SO CHIA TOI UU L = " << l << endl;


	Hanoi4(l, 4, cotnguon, trunggian1, trunggian2, cotdich);
	Hanoi3(n - l, cotnguon, cotdich, trunggian2);
	Hanoi4(l, 4, trunggian1, cotdich, trunggian2, cotnguon);
	
}



void Hanoi3(int n, int cotnguon, int cotdich, int cottg)
{
	if(n == 1)
	{
		cout << "Move " << cotnguon << " to1 " << cotdich << endl;
		solan++;
		return;
	}

	Hanoi3(n - 1, cotnguon, cottg, cotdich);
	cout << "Move " << cotnguon << " to1 " << cotdich << endl;
	solan++;
	Hanoi3(n - 1, cottg, cotdich, cotnguon);
}


/*

	if(n == 4)
	{
		//Phat dia
		cout << "Move " << cotnguon << " to4 " << trunggian1 << endl;
		cout << "Move " << cotnguon << " to4 " << trunggian2 << endl;

		//Chuyen tu nguon sang dich
		
		cout << "Move " << trunggian1 << " to4 " << trunggian2 << endl;
		cout << "Move " << cotnguon << " to4 " << trunggian1 << endl;
		cout << "Move " << cotnguon << " to4 " << cotdich << endl;
		cout << "Move " << trunggian1 << " to4 " << cotdich << endl;
		cout << "Move " << trunggian2 << " to4 " << trunggian1 << endl;

		//Thu dia
		cout << "Move " << trunggian2 << " to4 " << cotdich << endl;
		cout << "Move " << trunggian1 << " to4 " << cotdich << endl;
		solan += 9;
		return;
	}

	         *             if (n == 3)
            {
                //Phat dia
                moves.Add(new Move(cotnguon, trunggian1));
                moves.Add(new Move(cotnguon, trunggian2));

                //Chuyen tu nguon sang dich
                moves.Add(new Move(cotnguon, cotdich));

                //Thu dia
                moves.Add(new Move(trunggian2, cotdich));
                moves.Add(new Move(trunggian1, cotdich));

                moveCounter += 5;
                return;
            }
	*/