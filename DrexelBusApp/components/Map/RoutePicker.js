import React from 'react';
import { View, Text, FlatList } from 'react-native';

class RoutePicker extends React.Component {
  state = {
    routes: []
  }

  componentDidMount(){
    console.log('componentdidmount');
    fetch('/api/route')
      .then((res) => res.json())
      .then((data) => {
        this.setState({
          routes: data
        });
      })
      .catch((error) => {
        console.error(error);
      });
  }

  render() {
    return (
      <View>
        <FlatList
          data={this.state.routes}
          renderItem={({item}) => <Text>{item.name}</Text>}
        />
      </View>
    );
  }
};

export default RoutePicker;