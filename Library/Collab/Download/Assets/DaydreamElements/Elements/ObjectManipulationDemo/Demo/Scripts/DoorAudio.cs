﻿// Copyright 2017 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace DaydreamElements.ObjectManipulation {

  using System;
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;

  /// Plays sounds for interactive doors.
  public class DoorAudio : MonoBehaviour {
    public enum ObjectState{ None, Selected, Released }

    [Tooltip("The HingeConstraint used by this script.")]
    public HingeConstraint door;

    [Tooltip("Sound played when the object is selected.")]
    //public GvrAudioSource selectSound;

    private bool isSelected;

    private BaseInteractiveObject.ObjectState state;
    private BaseInteractiveObject.ObjectState stateLastFrame;

    void OnValidate() {
      if (!door) {
        door = GetComponent<HingeConstraint>();
      }
    }

    void Awake() {
      isSelected = false;
    }

    void Update() {
      state = door.State;

      if (state == BaseInteractiveObject.ObjectState.Selected) {
        isSelected = true;
      } else {
        isSelected = false;
      }

      if (isSelected && state != stateLastFrame) {
        //if (selectSound != null) {
          //selectSound.Play();
        //}
      }

      stateLastFrame = door.State;
    }
  }
}