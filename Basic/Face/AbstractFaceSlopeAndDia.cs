﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;
using NXOpen.UF;

namespace Basic
{
    public abstract class AbstractFaceSlopeAndDia
    {
        public FaceData Data { get; }

        public AbstractFaceSlopeAndDia(FaceData data)
        {

            this.Data = data;
        }
        /// <summary>
        /// 获取斜率和半径
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="slope">slope[0]最小，slope[1]最大</param>
        /// <param name="dia">dia[0] 最小，dia[1]最大</param>
        public abstract void GetSlopeAndDia(Vector3d vec, out double[] slope, out double[] dia);
    }
}
