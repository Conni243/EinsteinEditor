﻿using Einstein.model;
using Einstein.ui.editarea.visibleElements;
using phi.graphics.drawables;
using phi.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einstein.ui.editarea
{
    public class SynapseMultiRenderable
    {
        public const int LAYER = 15;

        public NeuronDraggable From { get; private set; }
        public NeuronDraggable To { get; private set; }

        private Line line;
        private SynapseArrow arrow;
        private EditArea editArea;

        public SynapseMultiRenderable(EditArea editArea, NeuronDraggable from, int mouseX, int mouseY)
        {
            From = from;
            From.SubscribeOnDrag(UpdateBasePosition);
            line = new Line(
                from.NeuronDrawable.GetCircleCenterX(),
                from.NeuronDrawable.GetCircleCenterY(),
                mouseX, mouseY);
            arrow = new SynapseArrow(mouseX, mouseY,
                mouseX - from.NeuronDrawable.GetCircleCenterX(),
                mouseY - from.NeuronDrawable.GetCircleCenterY());
            this.editArea = editArea;
        }

        public void Initialize()
        {
            IO.RENDERER.Add(line, LAYER);
            IO.RENDERER.Add(arrow, LAYER);
            IO.MOUSE.MOVE.Subscribe(UpdateTipPositionXY);
            IO.MOUSE.RIGHT_UP.Subscribe(FinalizeTipPosition);
        }
        public void Uninitialize()
        {
            IO.RENDERER.Remove(line);
            IO.RENDERER.Remove(arrow);
            IO.MOUSE.MOVE.Unsubscribe(UpdateTipPositionXY);
            IO.MOUSE.RIGHT_UP.Unsubscribe(FinalizeTipPosition);
        }

        private void UpdateBasePosition()
        {
            UpdateBasePositionXY(From.NeuronDrawable.GetCircleCenterX(),
                               From.NeuronDrawable.GetCircleCenterY());
        }
        private void UpdateBasePositionXY(int x, int y)
        {
            line.SetXY1(x, y);
            arrow.SetDirection(
                line.GetX2() - x,
                line.GetY2() - y);
        }

        // Only use if To is set
        private void UpdateTipPosition()
        {
            // TODO fix to make it not overlap with the neuron circle
            int x = To.NeuronDrawable.GetCircleCenterX();
            int y = To.NeuronDrawable.GetCircleCenterY();
            UpdateTipPositionXY(x, y);
        }
        private void UpdateTipPositionXY(int x, int y)
        {
            line.SetXY2(x, y);
            arrow.SetXY(x, y);
            arrow.SetDirection(
                x - From.NeuronDrawable.GetCircleCenterX(),
                y - From.NeuronDrawable.GetCircleCenterY());
        }

        private void FinalizeTipPosition(int x, int y)
        {
            SetTipNeuron(editArea.HasNeuronAtPosition(x, y));
        }

        public void SetTipNeuron(NeuronDraggable dragNeuron)
        {
            To = dragNeuron;
            if (To == null)
            {
                Uninitialize();
                return;
            }

            IO.MOUSE.MOVE.Unsubscribe(UpdateTipPositionXY);
            IO.MOUSE.RIGHT_UP.Unsubscribe(FinalizeTipPosition);
            To.SubscribeOnDrag(UpdateTipPosition);
            UpdateTipPosition();
            editArea.AddSynapse(new BaseSynapse(From.Neuron, To.Neuron, 1f));
        }


    }
}