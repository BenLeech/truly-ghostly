using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart {
    int currentValue;
    int maxValue;

    public Heart(int currentValue, int maxValue) {
        this.currentValue = currentValue;
        this.maxValue = maxValue;
    }

    public void SetCurrentValue(int value) {
        currentValue = value;
    }

    public int GetCurrentValue() {
        return currentValue;
    }

    public int GetMaxValue() {
        return maxValue;
    }
}
