using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Models.SpaceShips;

public class ArmeImporteur
{
    private Dictionary<string, int> frequenceMots = new();
    public int MinLength { get; set; } = 3;
    public HashSet<string> BlackList { get; set; } = new HashSet<string>();
    private Random rnd = new Random();

    public List<Weapon> Weapons { get; private set; } = new List<Weapon>();

    public void ReadFile(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Fichier introuvable", filePath);

        string texte = File.ReadAllText(filePath);

        // Normalisation + suppression ponctuation
        var mots = Regex.Matches(texte.ToLower(), @"\b[\w']+\b")
            .Select(m => m.Value);

        foreach (var mot in mots)
        {
            if (ValiderMot(mot))
            {
                if (!frequenceMots.ContainsKey(mot))
                    frequenceMots[mot] = 0;
                frequenceMots[mot]++;
            }
        }

        foreach (var kvp in frequenceMots)
        {
            string name = kvp.Key;
            int freq = kvp.Value;

            double minDamage = name.Length + freq * 0.5;
            double maxDamage = name.Length + freq * 1.0;

            EWeaponType type = (EWeaponType)rnd.Next(Enum.GetValues(typeof(EWeaponType)).Length);
            double reloadTime = rnd.Next(1, 4);

            Weapon weapon = new Weapon(name, minDamage, maxDamage, type, reloadTime);

            if (!Armory.IsWeaponFromArmory(weapon))
            {
                Armory.Weapons.Add(weapon);
            }
        }
    }

    private bool ValiderMot(string mot)
    {
        if (mot.Length < MinLength)
            return false;
        if (BlackList.Contains(mot))
            return false;
        return true;
    }

    public Dictionary<string, int> GetFrequences()
    {
        return frequenceMots
            .OrderByDescending(kvp => kvp.Value)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
}
