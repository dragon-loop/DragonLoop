import React from 'react';
import { View } from 'react-native';
import Map from './Map';
import RoutePicker from './RoutePicker';

class MapScreen extends React.Component {
  render() {
    return (
      <View style={{flex: 1, flexDirection: 'column'}}>
        <Map />
        <RoutePicker />
      </View>      
    );
  }
};

export default MapScreen;