# Adapter Pattern in C#

## Overview

The Adapter Pattern is a structural design pattern that allows objects with incompatible interfaces to work together. It acts as a bridge between two incompatible interfaces by wrapping the interface of one class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.

This pattern involves three key components:

- **Target**: The interface that the client expects or uses.
- **Adaptee**: The class that needs to be adapted. This class contains some useful behavior, but its interface is incompatible with the client.
- **Adapter**: The class that implements the target interface and wraps an adaptee object to provide the expected interface.

## Types of Adapter Pattern

There are two types of Adapter Pattern implementations:

1. **Class Adapter**: Uses multiple inheritance (interface inheritance in C#) to adapt one interface to another.
2. **Object Adapter**: Uses composition to contain the adaptee in the adapter object, and implement the target interface to call upon the adaptee.

## Example

In this example, we demonstrate the Object Adapter Pattern in C#. We have a `LightningPhone` interface (Adaptee) and a `MicroUsbPhone` interface (Target). We want our `LightningPhone` to be compatible with a `MicroUsbPhone` charger. Therefore, we'll create an `Adapter` that implements the `MicroUsbPhone` interface and uses a `LightningPhone` instance to fulfill the requests.

### Step 1: Define Target Interface

```csharp
public interface MicroUsbPhone
{
    void Recharge();
    void UseMicroUsb();
}
```

### Step 2: Define Adaptee Interface

```csharp
public interface LightningPhone
{
    void Recharge();
    void UseLightning();
}
```

### Step 3: Implement the Adaptee

```csharp
public class IPhone : LightningPhone
{
    private bool connector;

    public void UseLightning()
    {
        connector = true;
        Console.WriteLine("Lightning connected");
    }

    public void Recharge()
    {
        if (connector)
        {
            Console.WriteLine("Recharge started");
            Console.WriteLine("Recharge finished");
        }
        else
        {
            Console.WriteLine("Connect Lightning first");
        }
    }
}
```

### Step 4: Create the Adapter

```csharp
public class LightningToMicroUsbAdapter : MicroUsbPhone
{
    private readonly LightningPhone lightningPhone;

    public LightningToMicroUsbAdapter(LightningPhone lightningPhone)
    {
        this.lightningPhone = lightningPhone;
    }

    public void UseMicroUsb()
    {
        Console.WriteLine("MicroUsb connected");
        lightningPhone.UseLightning();
    }

    public void Recharge()
    {
        lightningPhone.Recharge();
    }
}
```

### Step 5: Utilize the Adapter

```csharp
class Program
{
    static void Main(string[] args)
    {
        IPhone iPhone = new IPhone();
        LightningToMicroUsbAdapter adapter = new LightningToMicroUsbAdapter(iPhone);

        adapter.UseMicroUsb();
        adapter.Recharge();
    }
}
```

In this example, `LightningToMicroUsbAdapter` adapts an `IPhone` (which uses a Lightning connector) to be charged by a MicroUsb charger. The adapter translates calls from the `MicroUsbPhone` interface to the compatible `LightningPhone` interface calls.

## Conclusion

The Adapter Pattern is crucial for ensuring that classes with incompatible interfaces can work together. It's widely used in software development for integrating new features or libraries without changing the existing codebase. This pattern adds flexibility to the code by allowing objects with different interfaces to communicate and operate together.
