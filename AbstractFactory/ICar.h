#pragma once
#include<string>
//≥ÈœÛ¿‡
class ICar
{
public:
	ICar();
	~ICar();
public:
	virtual std::string Name() = 0;
};

class IBike {
public:
	virtual std::string Name() = 0;
};

class BenzCar :public ICar
{
public:
	std::string Name()
	{
		return "Benz Car";
	}
};
class AudiCar :public ICar
{
public :
	std::string Name()
	{
		return "Audi Car";
	}
};
class BenzBike :public IBike
{
public:
	std::string Name()
	{
		return "BenzBike";
	}
};
class AudiBike :public IBike
{
public:
	std::string Name()
	{
		return "AudiBike";
	}
};

class AFactory
{
public:
	enum Factory_Type
	{
		Benz_Factory,
		Audi_actory,
	};
	virtual ICar* CreateCar() = 0;
	virtual IBike* CreateBike() = 0;
	static AFactory* CreateFactory(Factory_Type type);
};

class BenzFactory :public AFactory
{
public:
	ICar* CreateCar()
	{
		return new BenzCar();
	}
	IBike* CreateBike()
	{
		return new BenzBike();
	}
};
class AudiFactory :public AFactory
{
public:
	ICar* CreateCar()
	{
		return new AudiCar();
	}
	IBike* CreateBike()
	{
		return new AudiBike();
	}
};


AFactory* AFactory::CreateFactory(Factory_Type type)
{
	AFactory *pFactory = NULL;
	switch(type)
	{
	case Factory_Type::Benz_Factory:
		pFactory = new BenzFactory();
		break;
	case Factory_Type::Audi_actory:
		pFactory = new AudiFactory();
		break;
	}
	return pFactory;
}
