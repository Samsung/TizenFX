# I<sup>2</sup>C

[I<sup>2</sup>C](https://en.wikipedia.org/wiki/I%C2%B2C) (Inter-Integrated Circuit) is a programmable interface that allows you to communicate with I<sup>2</sup>C peripherals.

I<sup>2</sup>C is a synchronous serial interface that uses a clock signal to synchronize data transfers between master and slave device:

-   Master device generates the clock and initiates communication with slaves.
-   Slave device receives the clock and responds when addressed by the master.

**Figure: I<sup>2</sup>C interface diagram**

![I2C interface diagram](media/peri_api_i2c_diagram.png)

To allow the I<sup>2</sup>C master to connect to 128 I<sup>2</sup>C slave devices, an I<sup>2</sup>C slave device provides a 7-bit address. Since most slave addresses are determined by the manufacturer, refer to the specification to find the slave device address.

Using the I<sup>2</sup>C bus, the master controls signal lines called SCL (Shared CLock) and SDA (Shared DAta) to read or write data to or from the device. SCL is a clock line for communication synchronization, and SDA is a data line. The master outputs the clock for synchronization with the SCL, and the slave outputs or receives data through the SDA according to the clock output to the SCL.

If the SDA line is used alone, only half duplex communication is possible because data is sent only to 1 line.

## Opening and Closing a Handle

To open and close a handle:

1.  To open an I<sup>2</sup>C handle, create the `I2cDevice` object:

    ```csharp
    int bus = 1;
    int address = ...;   /* See the specification */
    I2cDevice i2c = new I2cDevice(bus, address);
    ```

    The `bus` parameter required for this function must be set according to the following table.

    **Table: Raspberry Pi 3 and Raspberry Pi 4**

    Pin name  |           |Bus number (parameter 1)
    ----------|-----------|----------
    I2C1\_SDA | I2C1\_SCL | 1

    > **Note**
    >
    > For more information on the pin names and locations, see [Supported Protocols](peripheral.md#protocol).

    The `address` parameter must be set based on the peripheral specification.

2.  To close an I<sup>2</sup>C handle that is no longer used, use the `I2cDevice.Close()` method:

    ```csharp
    i2c.Close();
    ```

## Reading and Writing Data

To read and write data:

-   To write bytes to a slave device, use the `I2cDevice.Write()` method:

    ```csharp
    byte[] data = {0x06, 0x01};
    i2c.Write(data);
    ```

-   To read bytes from a slave device, use the `I2cDevice.Read()` method:

    ```csharp
    byte[] data = new byte[2];
    i2c.Read(data);
    ```

## Reading and Writing Register Data

To read and write register data:

-   To write single byte data to a slave device register, use the `I2cDevice.WriteRegisterByte()` method:

    ```csharp
    byte data = 0x06;
    byte register_address = ...;  /* See the specification */
    i2c.WriteRegisterByte(register_address, data);
    ```

-   To read single byte data from a slave device register, use the `I2cDevice.ReadRegisterByte()` method:

    ```csharp
    byte data;
    byte register_address = ...;  /* See the specification */
    data = i2c.ReadRegisterByte(register_address);
    ```

-   To write word data to a slave device register, use the `I2cDevice.WriteRegisterWord()` method:

    ```csharp
    ushort data = 0xffff;
    byte register_address = ...;  /* See the specification */
    i2c.WriteRegisterWord(register_address, data);
    ```

-   To read word data from a slave device register, use the `I2cDevice.ReadRegisterByte()` method:

    ```csharp
    ushort data;
    byte register_address = ...;  /* See the specification */
    data = i2c.ReadRegisterByte(register_address);
    ```
