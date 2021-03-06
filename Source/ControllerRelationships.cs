﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
namespace EdB.PrepareCarefully {
    public class ControllerRelationships {
        protected State state;
        public ControllerRelationships(State state) {
            this.state = state;
        }
        public void AddRelationship(PawnRelationDef def, CustomPawn source, CustomPawn target) {
            PrepareCarefully.Instance.RelationshipManager.AddRelationship(def, source, target);
        }
        public void RemoveRelationship(CustomRelationship relationship) {
            PrepareCarefully.Instance.RelationshipManager.DeleteRelationship(relationship);
        }
        public void DeleteAllPawnRelationships(CustomPawn pawn) {
            PrepareCarefully.Instance.RelationshipManager.DeletePawn(pawn);
        }
        public void AddPawn(CustomPawn pawn) {
            PrepareCarefully.Instance.RelationshipManager.AddVisibleParentChildPawn(pawn);
        }
        public void AddParentToParentChildGroup(CustomParentChildGroup group, CustomParentChildPawn pawn) {
            if (!group.Parents.Contains(pawn) && !group.Children.Contains(pawn)) {
                group.Parents.Add(pawn);
            }
        }
        public void RemoveParentFromParentChildGroup(CustomParentChildGroup group, CustomParentChildPawn pawn) {
            group.Parents.Remove(pawn);
            if (group.Parents.Count == 0 && group.Children.Count == 0) {
                PrepareCarefully.Instance.RelationshipManager.RemoveParentChildGroup(group);
            }
        }
        public void AddChildToParentChildGroup(CustomParentChildGroup group, CustomParentChildPawn pawn) {
            if (!group.Parents.Contains(pawn) && !group.Children.Contains(pawn)) {
                group.Children.Add(pawn);
            }
        }
        public void RemoveChildFromParentChildGroup(CustomParentChildGroup group, CustomParentChildPawn pawn) {
            group.Children.Remove(pawn);
            if (group.Parents.Count == 0 && group.Children.Count == 0) {
                PrepareCarefully.Instance.RelationshipManager.RemoveParentChildGroup(group);
            }
        }
        public void AddParentChildGroup(CustomParentChildGroup group) {
            PrepareCarefully.Instance.RelationshipManager.ParentChildGroups.Add(group);
        }
    }
}
