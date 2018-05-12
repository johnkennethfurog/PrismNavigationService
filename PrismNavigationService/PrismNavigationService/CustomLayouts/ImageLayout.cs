using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrismNavigationService.CustonLayouts
{
    public class ImageLayout : Layout<View>
    {
        public static readonly BindableProperty ItemSourceProperty =
            BindableProperty.Create(nameof(ItemSource), typeof(IEnumerable),typeof(ImageLayout), null,propertyChanged:CollecitonChanged);

        public static ImageLayout layout;

        public bool PerformCalculation { get; set; }

        private static void CollecitonChanged(BindableObject bindable, object oldValue, object newValue)
        {
            layout = bindable as ImageLayout;
            
            var list = newValue as ObservableCollection<string>;
            layout.ReCreateChildrens();
            list.CollectionChanged += List_CollectionChanged;
        }

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(nameof(ItemTemplate),typeof(DataTemplate),typeof(ImageLayout),default(DataTemplate), propertyChanged: OnItemsTemplateChanged);

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }
        private static void OnItemsTemplateChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var view = (ImageLayout)bindable;
            view.ReCreateChildrens();
        }

        private void ReCreateChildrens()
        {
            if (ItemSource == null || ItemTemplate == null)
                return;

            foreach (var item in ItemSource)
            {
                var view = ItemTemplate.CreateContent() as View;
                view.BindingContext = item;
                Children.Add(view);
            }
        }

        private static void List_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                layout.PerformCalculation = false;
                var lasItem = e.NewItems.Count -1;
                var ind = 0;
                foreach(var item in e.NewItems)
                {
                    if (lasItem == ind)
                        layout.PerformCalculation = true;

                    var view = layout.ItemTemplate.CreateContent() as View;
                    view.BindingContext = item;
                    layout.Children.Add(view);
                    ind++;



                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                layout.Children.RemoveAt(e.OldStartingIndex);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Move)
            {
                var item = layout.Children[e.OldStartingIndex];
                layout.Children.RemoveAt(e.OldStartingIndex);
                layout.Children.Insert(e.NewStartingIndex, item);
            }
        }

        public ImageLayout()
        {
        }

        static Image newView(string path, ImageLayout layout)
        {
            var imgView = new Image();
            imgView.Source = path;
            //imgView.SetBinding(PhotoView.RemoveCommandProperty, new Binding("RemoveImageCommand", source: layout.BindingContext));
            return imgView;
        }

        public IEnumerable ItemSource
        {
            get { return (IEnumerable) GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }


        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            //if(!PerformCalculation)
            //    return new SizeRequest(new Size(widthConstraint, 0));

            if (Children.Count == 1)
            {
                return new SizeRequest(new Size(widthConstraint, 300));
            }
            else if (Children.Count == 2)
            {
                return new SizeRequest(new Size(widthConstraint, widthConstraint/2));
            }
            else if (Children.Count == 3)
            {
                return new SizeRequest(new Size(widthConstraint, 400));
            }
            else if (Children.Count == 4)
            {
                return new SizeRequest(new Size(widthConstraint, 300));
            }
            else if (Children.Count >= 5)
            {
                return new SizeRequest(new Size(widthConstraint, 300));
            }
            else
            {
                return new SizeRequest(new Size(widthConstraint, 0));
            }
        }


        private LayoutState _state = LayoutState.NoImage;
        enum LayoutState
        {
            NoImage,
            OneImage,
            TwoImage,
            ThreeImage,
            FourImage,
            FiveImage,
            ManyImage
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            //if (!PerformCalculation)
            //    return;

            if (Children.Count == 1 && _state != LayoutState.OneImage)
            {
                _state = LayoutState.OneImage;
                LayoutChildIntoBoundingRegion(Children[0], new Rectangle(x, y, width, 300));
            }
            else if (Children.Count == 2 && _state != LayoutState.TwoImage)
            {
                _state = LayoutState.TwoImage;
                var w = width / 2;
                LayoutChildIntoBoundingRegion(Children[0], new Rectangle(x, y, w, w));
                LayoutChildIntoBoundingRegion(Children[1], new Rectangle(x + w, y, w, w));
            }
            else if (Children.Count == 3 && _state != LayoutState.ThreeImage)
            {
                _state = LayoutState.ThreeImage;
                var h = 400 / 3;
                var w = width / 2;
                LayoutChildIntoBoundingRegion(Children[0], new Rectangle(x, y, Width, h * 2));
                LayoutChildIntoBoundingRegion(Children[1], new Rectangle(x, y + h * 2, w, h));
                LayoutChildIntoBoundingRegion(Children[2], new Rectangle(x + w, y + h *2, w, h));
            }
            else if (Children.Count == 4 && _state != LayoutState.FourImage)
            {
                _state = LayoutState.FourImage;
                var h = 300 / 2;
                var w = width / 2;
                LayoutChildIntoBoundingRegion(Children[0], new Rectangle(x, y, w, h));
                LayoutChildIntoBoundingRegion(Children[1], new Rectangle(x + w, y, w, h));
                LayoutChildIntoBoundingRegion(Children[2], new Rectangle(x, y + h, w, h));
                LayoutChildIntoBoundingRegion(Children[3], new Rectangle(x + w, y + h, w, h));
            }
            else if (Children.Count >= 5)
            {

                var baseHeight = 300 / 5;
                var upperHeight = baseHeight * 3;
                var lowerHeight = baseHeight * 2;


                var upperWidth = width / 2;
                var lowerWidth = width / 3;

                if(_state != LayoutState.FiveImage)
                {
                    _state = LayoutState.FiveImage;

                    LayoutChildIntoBoundingRegion(Children[0], new Rectangle(x, y, upperWidth, upperHeight));
                    LayoutChildIntoBoundingRegion(Children[1], new Rectangle(x + upperWidth, y, upperWidth, upperHeight));
                    LayoutChildIntoBoundingRegion(Children[2], new Rectangle(x, y + upperHeight, lowerWidth, lowerHeight));
                    LayoutChildIntoBoundingRegion(Children[3], new Rectangle(x + lowerWidth, y + upperHeight, lowerWidth, lowerHeight));
                    LayoutChildIntoBoundingRegion(Children[4], new Rectangle(x + (lowerWidth * 2), y + upperHeight, lowerWidth, lowerHeight));

                }

                if (Children.Count >= 6 && _state != LayoutState.ManyImage)
                {
                    _state = LayoutState.ManyImage;
                    var endHeight = height / 5;
                    LayoutChildIntoBoundingRegion(Children[5], new Rectangle(x + (lowerWidth * 2), height - endHeight, lowerWidth, endHeight));
                }
            }
            else
            {
                _state = LayoutState.NoImage;
            }
        }
    }
}
