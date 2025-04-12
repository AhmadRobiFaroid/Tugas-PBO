using System;

// Parent class
public class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;

    // Constructor
    public Karyawan(string nama, string id, double gajiPokok)
    {
        this.nama = nama;
        this.id = id;
        this.gajiPokok = gajiPokok;
    }

    // Getter dan Setter
    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }

    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public double GajiPokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }

    // Virtual method untuk dioverride
    public virtual double HitungGaji()
    {
        return gajiPokok;
    }
}

// Child class Karyawan Tetap
public class KaryawanTetap : Karyawan
{
    public KaryawanTetap(string nama, string id, double gajiPokok) 
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return base.GajiPokok + 500000; // Bonus tetap 500.000
    }
}

// Child class Karyawan Kontrak
public class KaryawanKontrak : Karyawan
{
    public KaryawanKontrak(string nama, string id, double gajiPokok) 
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return base.GajiPokok - 200000; // Potongan 200.000
    }
}

// Child class Karyawan Magang
public class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string id, double gajiPokok) 
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return base.GajiPokok; // Tanpa perubahan
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("SISTEM MANAJEMEN KARYAWAN");
        Console.WriteLine("=========================");

        // Input data karyawan
        Console.Write("Jenis Karyawan (1. Tetap, 2. Kontrak, 3. Magang): ");
        int jenis = Convert.ToInt32(Console.ReadLine());

        Console.Write("Nama Karyawan: ");
        string nama = Console.ReadLine();

        Console.Write("ID Karyawan: ");
        string id = Console.ReadLine();

        Console.Write("Gaji Pokok: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        // Buat objek sesuai jenis
        Karyawan karyawan = null;
        switch (jenis)
        {
            case 1:
                karyawan = new KaryawanTetap(nama, id, gajiPokok);
                break;
            case 2:
                karyawan = new KaryawanKontrak(nama, id, gajiPokok);
                break;
            case 3:
                karyawan = new KaryawanMagang(nama, id, gajiPokok);
                break;
            default:
                Console.WriteLine("Jenis karyawan tidak valid!");
                return;
        }

        // Hitung dan tampilkan gaji
        double gajiAkhir = karyawan.HitungGaji();
        Console.WriteLine("\nRINCIAN GAJI");
        Console.WriteLine("Nama: " + karyawan.Nama);
        Console.WriteLine("ID: " + karyawan.ID);
        Console.WriteLine("Gaji Pokok: " + karyawan.GajiPokok.ToString("C"));
        Console.WriteLine("Gaji Akhir: " + gajiAkhir.ToString("C"));
    }
}
