using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedAttributes : MonoBehaviour {
    // all things static
    // Sprites
    private SpriteRenderer selectedHair;
    private SpriteRenderer selectedSkin;
    private SpriteRenderer selectedShirt;
    private SpriteRenderer selectedPants;
    private SpriteRenderer selectedLineart;
    private SpriteRenderer selectedSkinShading;
    private SpriteRenderer selectedClothShading;

    // colors of Sprites
    private Color selectedSkinColor;
    private Color selectedHairColor;
    private Color selectedShirtColor;
    private Color selectedPantsColor;

    // int
    private int selectedSkinPos = 0;
    private int selectedHairPos = 0;
    private int selectedSkinColorPos = 0;
    private int selectedHairColorPos = 0;
    private int selectedShirtColorPos = 0;
    private int selectedPantsColorPos = 0;
    private int selectedCisOrTransInt = 0;
    private int selectedPronounInt = 0;

    public SpriteRenderer SelectedHair
    { get; set; }

    public SpriteRenderer SelectedSkin
    { get; set; }

    public SpriteRenderer SelectedShirt
    { get; set; }

    public SpriteRenderer SelectedPants
    { get; set; }

    public SpriteRenderer SelectedLineart
    { get; set; }

    public SpriteRenderer SelectedSkinShading
    { get; set; }

    public SpriteRenderer SelectedClothShading
    { get; set; }
}
