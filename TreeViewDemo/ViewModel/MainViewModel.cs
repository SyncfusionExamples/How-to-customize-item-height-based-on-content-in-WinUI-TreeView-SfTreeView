using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TreeViewDemo
{
    public class MainViewModel
    {
        public ObservableCollection<Item> GroupedJobDescription { get; }

        public MainViewModel()
        {
            GroupedJobDescription = new ObservableCollection<Item>
            {
                new Item
                {
                    ComponentNameLong ="Engine",

                    Details = new ObservableCollection<Item>
                    {
                        new Item
                        {
                            Category =
                                "Engine Performance Specifications and Technical Characteristics",

                            Detail =
                                "Maximum Power Output",

                            Value =
                                "The engine delivers a maximum power output of 120 horsepower at 6,000 RPM, "
                              + "ensuring smooth acceleration, reliable highway performance, and efficient "
                              + "power delivery under both city and long‑distance driving conditions.",

                            IconGlyph = "\uE9A6"
                        },
                        new Item
                        {
                            Category =
                                "Engine Performance Specifications and Technical Characteristics",

                            Detail =
                                "Peak Torque",

                            Value =
                                "The powertrain produces 180 Newton‑meters of torque at 4,000 RPM, "
                              + "providing strong low‑end response, reduced gear shifting, and improved "
                              + "drivability in traffic and inclined terrains.",

                            IconGlyph = "\uE9A6"
                        }
                    }
                },
                new Item
                {
                    ComponentNameLong = "Transmission",

                    Details = new ObservableCollection<Item>
                    {
                        new Item
                        {
                            Category =
                                "Transmission and Drivetrain Configuration Details",

                            Detail =
                                "Gearbox Type",

                            Value =
                                "The vehicle is equipped with a 6‑speed manual transmission designed "
                              + "for precise gear engagement, reduced mechanical friction, and improved "
                              + "fuel efficiency across a wide range of driving conditions.",

                            IconGlyph = "\uE7C8"
                        },
                        new Item
                        {
                            Category =
                                "Transmission and Drivetrain Configuration Details",

                            Detail =
                                "Operational Runtime Characteristics",

                            Value =
                                "This transmission system supports extended continuous operation with "
                              + "optimized lubrication and heat dissipation, ensuring reliable performance "
                              + "even during long‑duration or high‑load driving scenarios.",

                            IconGlyph = "\uE7C8"
                        }
                    }
                }
            };
        }
    }
}
