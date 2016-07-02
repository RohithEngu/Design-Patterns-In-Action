#include <iostream>
#include <string>

using namespace std;

class Component
{
public:
	virtual void operation() = 0;
};

class ConcreteComponent : public Component
{
	void operation() override { cout << "pattern"; }
};

class Decorator : public Component
{
	Component & component;
	void beforeOperation() { cout << "decorator "; }
	void afterOperation() { cout << "."; }

public:
	Decorator(Component & c) : component(c) { }
	void operation() override
	{
		beforeOperation();
		component.operation();
		afterOperation();
	}
	
};

int main()
{
	//Part 1
	ConcreteComponent comp1;
	Decorator dec1(comp1);
	
	
	Component &comp = dec1;
	// decorator is also a component so can be also decorated
	Decorator dec2(comp);

	dec1.operation();
	
	Component *currentItem;
	Component *comp2 = new ConcreteComponent();
	Component *dec = new Decorator(std::ref(*comp2));
	currentItem = comp2;
	currentItem->operation();
	currentItem = dec;
	currentItem->operation();
	currentItem = comp2;
	currentItem->operation();


	cout << endl;
	dec2.operation();
	cout << endl;

	return 0;
}