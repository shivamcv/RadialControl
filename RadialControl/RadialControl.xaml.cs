using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RadialControl
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RadialControl : Page
    {
        public RadialControl()
        {
            this.InitializeComponent();

            r0.Tag = q0;
            r1.Tag = q1;
            r2.Tag = q2;
            r3.Tag = q3;
            r4.Tag = q4;
            r5.Tag = q5;
            r6.Tag = q6;
            r7.Tag = q7;



           




            
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

     

        private void p_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Path p = (Path)sender;

            p.Stroke = (SolidColorBrush)this.Resources["OuterArcPointerOverColor"];

            
        }

        private void p_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Path p = (Path)sender;

            p.Stroke = (SolidColorBrush)this.Resources["OuterArcColor"];

        }

      

        private void r_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Path r = (Path)sender;
            Path q = (Path)r.Tag;

            Storyboard strbd = new Storyboard();

            DoubleAnimation AppearAnimation = new DoubleAnimation();

            AppearAnimation.Duration = TimeSpan.FromMilliseconds(150);
            AppearAnimation.To = 1;
            AppearAnimation.From = 0;

            strbd.Children.Add(AppearAnimation);

           //strbd.Duration = TimeSpan.FromMilliseconds(15);
            Storyboard.SetTargetProperty(AppearAnimation, "(UIElement.Opacity)");
            Storyboard.SetTarget(AppearAnimation, q);

             strbd.Begin();


        }

        private void r_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Path r = (Path)sender;
            Path q = (Path)r.Tag;

           
            Storyboard strbd = new Storyboard();

            DoubleAnimation FadeAnimation = new DoubleAnimation();

            FadeAnimation.Duration = TimeSpan.FromMilliseconds(150);
            FadeAnimation.To = 0;
            FadeAnimation.From = 1;


            strbd.Children.Add(FadeAnimation);

           // strbd.Duration = TimeSpan.FromMilliseconds(15);
            Storyboard.SetTargetProperty(FadeAnimation, "(UIElement.Opacity)");
            Storyboard.SetTarget(FadeAnimation, q);
            strbd.Begin();

        }


        bool isOpen = false;

        private void CenterButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (isSubMenuOpened)
            {
                isSubMenuOpened = !isSubMenuOpened;
                storyboardShowmenu.Begin();
                OpenImage.Visibility = Windows.UI.Xaml.Visibility.Visible;
                CloseImage.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            }
            else
            {
               

                if (!isOpen) //opening
                {



                    Storyboard strbd = (Storyboard)this.Resources["storyboardRootOpen"];

                    

                    strbd.Completed += strbd_Completed;
                    strbd.Begin();
                    isOpen = true;

                }
                else //closing
                {
                    //p0.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    //p1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    //p2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    //p3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    //p4.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    //p5.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    //p6.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    //p7.Visibility = Windows.UI.Xaml.Visibility.Collapsed;



                    Storyboard strbdClose = (Storyboard)this.Resources["storyboardRootClose"];

                   
                    strbdClose.Begin();
                    isOpen = false;

                }
            }
        }

        void strbd_Completed(object sender, object e)
        {
            


            //p0.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //p1.Visibility = Windows.UI.Xaml.Visibility.Visible;
                                                   
            //p2.Visibility = Windows.UI.Xaml.Visibility.Visible;
                                                   
            //p3.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //p4.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //p5.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //p6.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //p7.Visibility = Windows.UI.Xaml.Visibility.Visible;

           

            

            storyboardShowLabels.Begin();


        }


        bool isSubMenuOpened = false;

        private void p_Tapped(object sender, TappedRoutedEventArgs e)
        {
            storyboardHideSubmenu.Begin();

            storyboardHideSubmenu.Completed += storyboardHideSubmenu_Completed;

            isSubMenuOpened = true;
            OpenImage.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            CloseImage.Visibility = Windows.UI.Xaml.Visibility.Visible;

        }

        void storyboardHideSubmenu_Completed(object sender, object e)
        {
            storyboardShowSubmenu.Begin();
        }
    }
}
