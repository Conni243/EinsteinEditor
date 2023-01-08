﻿using phi.graphics.drawables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einstein.ui.editarea.visibleElements
{
    public class SynapseArrow : PenDrawable 
    {
        private const float HALF_WIDTH = 8f;
        private const float LENGTH = 16f;
        private int leftBaseX;
        private int leftBaseY;
        private int rightBaseX;
        private int rightBaseY;

        public SynapseArrow(int tipX, int tipY, float slopeDeltaX, float slopeDeltaY)
            : base(tipX, tipY, 0, 0)
        {
            SetDirection(slopeDeltaX, slopeDeltaY);
        }

        protected override void DrawAt(Graphics g, int x, int y)
        {
            g.DrawLine(GetPen(), x, y, leftBaseX, leftBaseY);
            g.DrawLine(GetPen(), x, y, rightBaseX, rightBaseY);
        }

        public void SetDirection(float slopeDeltaX, float slopeDeltaY)
        {
            if (slopeDeltaX == 0 && slopeDeltaY == 0)
            {
                // direction isn't defined, so just keep previous direction
                return;
            }
            float inputSlopeLength = (float)Math.Sqrt(
                slopeDeltaX * slopeDeltaX + slopeDeltaY * slopeDeltaY);
            float dX = -slopeDeltaX / inputSlopeLength;
            float dY = -slopeDeltaY / inputSlopeLength;
            float baseX = GetX() + dX * LENGTH;
            float baseY = GetY() + dY * LENGTH;

            leftBaseX = (int)(baseX + dY * HALF_WIDTH);
            leftBaseY = (int)(baseY - dX * HALF_WIDTH);
            rightBaseX = (int)(baseX - dY * HALF_WIDTH);
            rightBaseY = (int)(baseY + dX * HALF_WIDTH);
        }
    }
}
