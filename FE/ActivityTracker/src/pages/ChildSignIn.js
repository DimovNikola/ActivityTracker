import React from 'react';
import {SafeAreaView, View, Text} from 'react-native';
import {Button, TextInput} from 'react-native-paper';

function ChildSignIn({navigation}) {
  return (
    <SafeAreaView>
      <View>
        <View>
          <Text>What is your name?</Text>
          <TextInput />
        </View>
        <View>
          <Text>Enter your password here</Text>
          <TextInput />
        </View>
        <View>
          <Button
            mode="contained"
            style={{backgroundColor: 'gray'}}
            icon="arrow-left"
            onPress={() => navigation.navigate('SignIn')}></Button>
          <Button mode="contained" style={{backgroundColor: 'gray'}}>
            Let's Get Started
          </Button>
        </View>
      </View>
    </SafeAreaView>
  );
}

export default ChildSignIn;
