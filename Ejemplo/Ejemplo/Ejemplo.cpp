
#include "stdafx.h"
#include <iostream>
#include <queue>
#include <ctime>

using namespace std;

int main()
{
	priority_queue<int> pq;

	int cases;
		
	cin >> cases;

	for (int i = 0; i < cases; i++)
	{
		int a, b;

		cin >> a >> b;
		
		pq.push(a);
		pq.push(b);

	}


	return 0;
}

