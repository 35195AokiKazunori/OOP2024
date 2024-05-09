using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApps {
    internal class Bar : Obj {

        public Bar(double xp,double yp)
            : base(xp, yp, @"Picture\Bar.png") {
            MoveX = 10;
            MoveY = 0;
        }

        public Point Location { get; internal set; }

        

        public override bool Move(Keys direction) {
            if(direction == Keys.Right) {
                if (PosX < 635) {
                    PosX += MoveX;
                }
            }else if(direction == Keys.Left) {
                if (PosX > 0) {
                    PosX -= MoveX;
                }
            }

            return true;
        }

        public override bool Move(PictureBox pbBar, PictureBox pbBall) {
            throw new NotImplementedException();
        }
    }
}
