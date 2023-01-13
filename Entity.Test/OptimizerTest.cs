using NUnit.Framework;
using Entity;

namespace Entity.Test
{
    class OptimizerTest
    {
        public static void function1_grad(double[] x, ref double func, double[] grad, object obj)
        {
            // this callback calculates f(x0,x1) = 100*(x0+3)^4 + (x1-3)^4
            // and its derivatives df/dx0 and df/dx1
            func = 100 * System.Math.Pow(x[0] + 3, 4) + System.Math.Pow(x[1] - 3, 4);
            grad[0] = 400 * System.Math.Pow(x[0] + 3, 3);
            grad[1] = 4 * System.Math.Pow(x[1] - 3, 3);
        }

        [Test]
        public void mincg_d_1_example()
        {
            //
            // This example demonstrates minimization of
            //
            //     f(x,y) = 100*(x+3)^4+(y-3)^4
            //
            // 使用非線性共軛梯度法：using nonlinear conjugate gradient method with: 
            // * 初始點 x=[0,0] initial point x=[0,0] 
            // * 為所有變量設置單位比例 unit scale being set for all variables (see mincgsetscale for more info)
            // * 停止條件設置為“在足夠短的步驟後終止”stopping criteria set to "terminate after short enough step"
            // * OptGuard 完整性檢查用於檢查問題陳述 OptGuard integrity check being used to check problem statement
            //   對於一些常見的錯誤，例如不平滑或錯誤的解析梯度 for some common errors like nonsmoothness or bad analytic gradient
            //
            // 首先，我們創建優化器對象並調整其屬性 First, we create optimizer object and tune its properties
            //
            double[] x = new double[] { 0, 0 };
            double[] s = new double[] { 1, 1 };
            double epsg = 0;
            double epsf = 0;
            double epsx = 0.0000000001;
            int maxits = 0;
            alglib.mincgstate state;
            alglib.mincgcreate(x, out state);
            alglib.mincgsetcond(state, epsg, epsf, epsx, maxits);
            alglib.mincgsetscale(state, s);

            //
            // Activate OptGuard integrity checking.
            //
            // OptGuard monitor helps to catch common coding and problem statement
            // issues, like:
            // * discontinuity of the target function (C0 continuity violation)
            // * nonsmoothness of the target function (C1 continuity violation)
            // * erroneous analytic gradient, i.e. one inconsistent with actual
            //   change in the target/constraints
            //
            // OptGuard is essential for early prototyping stages because such
            // problems often result in premature termination of the optimizer
            // which is really hard to distinguish from the correct termination.
            //
            // IMPORTANT: GRADIENT VERIFICATION IS PERFORMED BY MEANS OF NUMERICAL
            //            DIFFERENTIATION. DO NOT USE IT IN PRODUCTION CODE!!!!!!!
            //
            //            Other OptGuard checks add moderate overhead, but anyway
            //            it is better to turn them off when they are not needed.
            //
            alglib.mincgoptguardsmoothness(state);
            alglib.mincgoptguardgradient(state, 0.001);

            //
            // Optimize and evaluate results
            //
            alglib.mincgreport rep;
            alglib.mincgoptimize(state, function1_grad, null, null);
            alglib.mincgresults(state, out x, out rep);
            System.Console.WriteLine("{0}", alglib.ap.format(x, 2)); // EXPECTED: [-3,3]

            //
            // Check that OptGuard did not report errors
            //
            // NOTE: want to test OptGuard? Try breaking the gradient - say, add
            //       1.0 to some of its components.
            //
            alglib.optguardreport ogrep;
            alglib.mincgoptguardresults(state, out ogrep);
            System.Console.WriteLine("{0}", ogrep.badgradsuspected); // EXPECTED: false
            System.Console.WriteLine("{0}", ogrep.nonc0suspected); // EXPECTED: false
            System.Console.WriteLine("{0}", ogrep.nonc1suspected); // EXPECTED: false
            //System.Console.ReadLine();
        }

        [Test]
        public void mincg_d_2_example()
        {
            //
            // This example demonstrates minimization of f(x,y) = 100*(x+3)^4+(y-3)^4
            // with nonlinear conjugate gradient method.
            //
            // Several advanced techniques are demonstrated:
            // * upper limit on step size
            // * restart from new point
            //
            double[] x = new double[] { 0, 0 };
            double[] s = new double[] { 1, 1 };
            double epsg = 0;
            double epsf = 0;
            double epsx = 0.0000000001;
            double stpmax = 0.1;
            int maxits = 0;
            alglib.mincgstate state;
            alglib.mincgreport rep;

            // create and tune optimizer
            alglib.mincgcreate(x, out state);
            alglib.mincgsetscale(state, s);
            alglib.mincgsetcond(state, epsg, epsf, epsx, maxits);
            alglib.mincgsetstpmax(state, stpmax);

            // Set up OptGuard integrity checker which catches errors
            // like nonsmooth targets or errors in the analytic gradient.
            //
            // OptGuard is essential at the early prototyping stages.
            //
            // NOTE: gradient verification needs 3*N additional function
            //       evaluations; DO NOT USE IT IN THE PRODUCTION CODE
            //       because it leads to unnecessary slowdown of your app.
            alglib.mincgoptguardsmoothness(state);
            alglib.mincgoptguardgradient(state, 0.001);

            // first run
            alglib.mincgoptimize(state, function1_grad, null, null);
            alglib.mincgresults(state, out x, out rep);
            System.Console.WriteLine("{0}", alglib.ap.format(x, 2)); // EXPECTED: [-3,3]

            // second run - algorithm is restarted with mincgrestartfrom()
            x = new double[] { 10, 10 };
            alglib.mincgrestartfrom(state, x);
            alglib.mincgoptimize(state, function1_grad, null, null);
            alglib.mincgresults(state, out x, out rep);
            System.Console.WriteLine("{0}", alglib.ap.format(x, 2)); // EXPECTED: [-3,3]

            // check OptGuard integrity report. Why do we need it at all?
            // Well, try breaking the gradient by adding 1.0 to some
            // of its components - OptGuard should report it as error.
            // And it may also catch unintended errors too :)
            alglib.optguardreport ogrep;
            alglib.mincgoptguardresults(state, out ogrep);
            System.Console.WriteLine("{0}", ogrep.badgradsuspected); // EXPECTED: false
            System.Console.WriteLine("{0}", ogrep.nonc0suspected); // EXPECTED: false
            System.Console.WriteLine("{0}", ogrep.nonc1suspected); // EXPECTED: false
        }

        public static void function1_func(double[] x, ref double func, object obj)
        {
            // this callback calculates f(x0,x1) = 100*(x0+3)^4 + (x1-3)^4
            func = 100 * System.Math.Pow(x[0] + 3, 4) + System.Math.Pow(x[1] - 3, 4);
        }

        [Test]
        public void mincg_numdiff_example()
        {
            //
            // This example demonstrates minimization of
            //
            //     f(x,y) = 100*(x+3)^4+(y-3)^4
            //
            // 使用數值微分來計算梯度。using numerical differentiation to calculate gradient.
            //
            // We also show how to use OptGuard integrity checker to catch common
            // problem statement errors like accidentally specifying nonsmooth target
            // function.
            //
            // First, we set up optimizer...
            //
            double[] x = new double[] { 0, 0 };
            double[] s = new double[] { 1, 1 };
            double epsg = 0;
            double epsf = 0;
            double epsx = 0.0000000001;
            double diffstep = 1.0e-6;
            int maxits = 0;
            alglib.mincgstate state;
            alglib.mincgcreatef(x, diffstep, out state);
            alglib.mincgsetcond(state, epsg, epsf, epsx, maxits);
            alglib.mincgsetscale(state, s);

            //
            // Then, we activate OptGuard integrity checking.
            //
            // 數值微分總是產生“正確”的梯度 Numerical differentiation always produces "correct" gradient
            // （有一些截斷錯誤，但沒有偏見）。 因此，我們只有 (with some truncation error, but unbiased). Thus, we just have
            // 檢查目標的平滑度屬性：C0 和 C1 的連續性。 to check smoothness properties of the target: C0 and C1 continuity.
            //
            // Sometimes user accidentally tried to solve nonsmooth problems
            // with smooth optimizer. OptGuard helps to detect such situations
            // early, at the prototyping stage.
            //
            alglib.mincgoptguardsmoothness(state);

            //
            // Now we are ready to run the optimization
            //
            alglib.mincgreport rep;
            alglib.mincgoptimize(state, function1_func, null, null);
            alglib.mincgresults(state, out x, out rep);
            System.Console.WriteLine("{0}", alglib.ap.format(x, 8)); // EXPECTED: [-3,3]

            //
            // ...and to check OptGuard integrity report.
            //
            // Want to challenge OptGuard? Try to make your problem
            // nonsmooth by replacing 100*(x+3)^4 by 100*|x+3| and
            // re-run optimizer.
            //
            alglib.optguardreport ogrep;
            alglib.mincgoptguardresults(state, out ogrep);
            System.Console.WriteLine("{0}", ogrep.nonc0suspected); // EXPECTED: false
            System.Console.WriteLine("{0}", ogrep.nonc1suspected); // EXPECTED: false
        }

        public static void functionMB_grad(double[] x, ref double func, double[] grad, object obj)
        {
            // this callback calculates f(Xn) = 6601368.8 - x0 - x1 - x2 - x3 - x4 - x5 - x6 - x7 - x8 - x9
            //                                  - x0x2 - x1x3 - x0x4 - x1x5 - x0x6 - x1x7 - x1x8 - x0x9
            //                                  - 99.9x0 - 91.3x1
            // and its derivatives df/dx0, df/dx1, and so on.
            //func = 100 * System.Math.Pow(x[0] + 3, 4) + System.Math.Pow(x[1] - 3, 4);
            func = 6601368.8 - x[0] - x[1] - x[2] - x[3] - x[4] - x[5] - x[6] - x[7] - x[8] - x[9]
                             - x[0] * x[2] - x[1] * x[3] - x[0] * x[4] - x[1] * x[5] - x[0] * x[6] - x[1] * x[7] - x[1] * x[8] - x[0] * x[9]
                             - 99.9 * x[0] - 91.3 * x[1];
            grad[0] = -1 - x[2] - x[4] - x[6] - x[9] - 99.9;
            grad[1] = -1 - x[3] - x[5] - x[7] - x[8] - 91.3;
            grad[2] = -1 - x[0];
            grad[3] = -1 - x[1];
            grad[4] = -1 - x[0];
            grad[5] = -1 - x[1];
            grad[6] = -1 - x[0];
            grad[7] = -1 - x[1];
            grad[8] = -1 - x[1];
            grad[9] = -1 - x[0];
        }
        [Test]
        public void mincg_d_1_MB()
        {
            //
            // This example demonstrates minimization of
            //
            //     f(Xn) = 6601368.8 - x0 - x1 - x2 - x3 - x4 - x5 - x6 - x7 - x8 - x9
            //                       - x0x2 - x1x3 - x0x4 - x1x5 - x0x6 - x1x7 - x1x8 - x0x9
            //                       - 99.9x0 - 91.3x1
            //
            // 使用非線性共軛梯度法：using nonlinear conjugate gradient method with: 
            // * 初始點 x=[0,0] initial point x=[0,0] 
            // * 為所有變量設置單位比例 unit scale being set for all variables (see mincgsetscale for more info)
            // * 停止條件設置為“在足夠短的步驟後終止”stopping criteria set to "terminate after short enough step"
            // * OptGuard 完整性檢查用於檢查問題陳述 OptGuard integrity check being used to check problem statement
            //   對於一些常見的錯誤，例如不平滑或錯誤的解析梯度 for some common errors like nonsmoothness or bad analytic gradient
            //
            // 首先，我們創建優化器對象並調整其屬性 First, we create optimizer object and tune its properties
            //
            double[] x = new double[] { 32680, 32680, 
                0.025, 2.175, 0.025, 2.175, 0.025, 2.175, 2.175, 0.025 };
            double[] s = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            double epsg = 0;
            double epsf = 0;
            double epsx = 0.0000000001;
            int maxits = 0;
            alglib.mincgstate state;
            alglib.mincgcreate(x, out state);
            alglib.mincgsetcond(state, epsg, epsf, epsx, maxits);
            alglib.mincgsetscale(state, s);

            //
            // Activate OptGuard integrity checking.
            //
            // OptGuard monitor helps to catch common coding and problem statement
            // issues, like:
            // * discontinuity of the target function (C0 continuity violation)
            // * nonsmoothness of the target function (C1 continuity violation)
            // * erroneous analytic gradient, i.e. one inconsistent with actual
            //   change in the target/constraints
            //
            // OptGuard is essential for early prototyping stages because such
            // problems often result in premature termination of the optimizer
            // which is really hard to distinguish from the correct termination.
            //
            // IMPORTANT: GRADIENT VERIFICATION IS PERFORMED BY MEANS OF NUMERICAL
            //            DIFFERENTIATION. DO NOT USE IT IN PRODUCTION CODE!!!!!!!
            //
            //            Other OptGuard checks add moderate overhead, but anyway
            //            it is better to turn them off when they are not needed.
            //
            alglib.mincgoptguardsmoothness(state);
            alglib.mincgoptguardgradient(state, 0.001);

            //
            // Optimize and evaluate results
            //
            alglib.mincgreport rep;
            alglib.mincgoptimize(state, functionMB_grad, null, null);
            alglib.mincgresults(state, out x, out rep);
            System.Console.WriteLine("{0}", alglib.ap.format(x, 2)); // EXPECTED: [-3,3]

            //
            // Check that OptGuard did not report errors
            //
            // NOTE: want to test OptGuard? Try breaking the gradient - say, add
            //       1.0 to some of its components.
            //
            alglib.optguardreport ogrep;
            alglib.mincgoptguardresults(state, out ogrep);
            System.Console.WriteLine("{0}", ogrep.badgradsuspected); // EXPECTED: false
            System.Console.WriteLine("{0}", ogrep.nonc0suspected); // EXPECTED: false
            System.Console.WriteLine("{0}", ogrep.nonc1suspected); // EXPECTED: false
            //System.Console.ReadLine();
        }

        public static void functionMB_func(double[] x, ref double func, object obj)
        {
            // this callback calculates f(Xn) = 6601368.8 - x0 - x1 - x2 - x3 - x4 - x5 - x6 - x7 - x8 - x9
            //                                  - x0x2 - x1x3 - x0x4 - x1x5 - x0x6 - x1x7 - x1x8 - x0x9
            //                                  - 99.9x0 - 91.3x1
            func = 6601368.8 - x[0] - x[1] - x[2] - x[3] - x[4] - x[5] - x[6] - x[7] - x[8] - x[9]
                             - x[0] * x[2] - x[1] * x[3] - x[0] * x[4] - x[1] * x[5] - x[0] * x[6] - x[1] * x[7] - x[1] * x[8] - x[0] * x[9]
                             - 99.9 * x[0] - 91.3 * x[1];
        }
        [Test]
        public void mincg_numdiff_MB()
        {
            //
            // This example demonstrates minimization of
            //
            //     f(x,y) = 100*(x+3)^4+(y-3)^4
            //
            // 使用數值微分來計算梯度。using numerical differentiation to calculate gradient.
            //
            // We also show how to use OptGuard integrity checker to catch common
            // problem statement errors like accidentally specifying nonsmooth target
            // function.
            //
            // First, we set up optimizer...
            //
            double[] x = new double[] { 32680, 32680,
                0.025, 2.175, 0.025, 2.175, 0.025, 2.175, 2.175, 0.025 };
            double[] s = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            double epsg = 0;
            double epsf = 0;
            double epsx = 0.0000000001;
            double diffstep = 1.0e-6;
            int maxits = 0;
            alglib.mincgstate state;
            alglib.mincgcreatef(x, diffstep, out state);
            alglib.mincgsetcond(state, epsg, epsf, epsx, maxits);
            alglib.mincgsetscale(state, s);

            //
            // Then, we activate OptGuard integrity checking.
            //
            // 數值微分總是產生“正確”的梯度 Numerical differentiation always produces "correct" gradient
            // （有一些截斷錯誤，但沒有偏見）。 因此，我們只有 (with some truncation error, but unbiased). Thus, we just have
            // 檢查目標的平滑度屬性：C0 和 C1 的連續性。 to check smoothness properties of the target: C0 and C1 continuity.
            //
            // Sometimes user accidentally tried to solve nonsmooth problems
            // with smooth optimizer. OptGuard helps to detect such situations
            // early, at the prototyping stage.
            //
            alglib.mincgoptguardsmoothness(state);

            //
            // Now we are ready to run the optimization
            //
            alglib.mincgreport rep;
            alglib.mincgoptimize(state, functionMB_func, null, null);
            alglib.mincgresults(state, out x, out rep);
            System.Console.WriteLine("{0}", alglib.ap.format(x, 2)); // EXPECTED: [-3,3]

            //
            // ...and to check OptGuard integrity report.
            //
            // Want to challenge OptGuard? Try to make your problem
            // nonsmooth by replacing 100*(x+3)^4 by 100*|x+3| and
            // re-run optimizer.
            //
            alglib.optguardreport ogrep;
            alglib.mincgoptguardresults(state, out ogrep);
            System.Console.WriteLine("{0}", ogrep.nonc0suspected); // EXPECTED: false
            System.Console.WriteLine("{0}", ogrep.nonc1suspected); // EXPECTED: false
        }
    }
}