import React from 'react';
import { createDrawerNavigator, createStackNavigator } from  'react-navigation';
import { TouchableOpacity } from 'react-native-gesture-handler';
import Icon from 'react-native-vector-icons/MaterialIcons';
import MapScreen from './Map/MapScreen';
import SettingsScreen from './Settings/SettingsScreen';

const NavigationOptions = ({ navigation }) => (
  <TouchableOpacity onPress={() => navigation.openDrawer()}>
      <Icon name="menu" size={30}/>
  </TouchableOpacity>
);

const MapStack = createStackNavigator(
  {
    MapScreen
  },
  {
    defaultNavigationOptions: ({ navigation }) => {
      return {
        headerLeft: <NavigationOptions navigation={navigation} />
      }
    }
  }
)

const SettingsStack = createStackNavigator(
  {
    SettingsScreen
  },
  {
    defaultNavigationOptions: ({ navigation }) => {
      return {
        headerLeft: <NavigationOptions navigation={navigation} />
      }
    }
  }
)

const AppNavigator = createDrawerNavigator(
  {
    Map: MapStack,
    Settings: SettingsStack
  }
);

export default AppNavigator;